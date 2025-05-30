using LRSprojectISS.domain;
using LRSprojectISS.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRSprojectISS.gui
{
    internal partial class UserHomepageForm : Form
    {
        private readonly Member _member;
        private readonly RentalService _rentalService;
        private readonly BookService _bookService;
        private int _currentPage = 1;
        private const int PageSize = 10;

        public UserHomepageForm(Member member, RentalService rentalService, BookService bookService)
        {
            InitializeComponent();
            _member = member;
            _rentalService = rentalService;
            _bookService = bookService;
            SearchTextBox.Text = "title: , author: , genre:";
            label1.Text = $"Hello, {member._name}";
            PerformSearch();
        }

        private void LoadRentals(IEnumerable<Rental> rentals)
        {
            RentalsDataGridView.Rows.Clear();

            foreach (var rental in rentals)
            {
                var status = GetRentalStatus(rental);
                int rowIndex = RentalsDataGridView.Rows.Add(
                    rental._book._title,
                    rental._book._author,
                    rental._book._publishDate.Year,
                    status,
                    rental._dueDate.ToShortDateString(),
                    "i"
                );

                RentalsDataGridView.Rows[rowIndex].Tag = rental;
            }
        }

        private RentalStatus GetRentalStatus(Rental rental)
        {
            if (rental._returnDate != null)
                return RentalStatus.Returned;
            return DateTime.Now > rental._dueDate ? RentalStatus.Overdue : RentalStatus.Pending;
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                PerformSearch();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            _currentPage++;
            PerformSearch();
        }

        private void PerformSearch()
        {
            string input = SearchTextBox.Text.Trim();
            string? title = null, author = null;
            Genre? genre = null;
            RentalStatus? status = null;

            var parts = input.Split(',');

            foreach (string part in parts)
            {
                string[] keyValue = part.Split(':');
                if (keyValue.Length != 2) continue;

                string key = keyValue[0].Trim().ToLower();
                string value = keyValue[1].Trim();

                switch (key)
                {
                    case "title":
                        title = value;
                        break;
                    case "author":
                        author = value;
                        break;
                    case "genre":
                        if (Enum.TryParse(typeof(Genre), value, true, out var genreParsed))
                            genre = (Genre)genreParsed;
                        break;
                }
            }

            string selectedStatus = StatusComboBox.SelectedItem?.ToString() ?? "Status";
            if (Enum.TryParse<RentalStatus>(selectedStatus, true, out var statusParsed) && selectedStatus != "Status")
            {
                status = statusParsed;
            }

            var rentals = _rentalService.SearchRentals(
                _member.Id,
                _currentPage,
                PageSize,
                title,
                author,
                status,
                genre
            );

            LoadRentals(rentals);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void RentalsDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var rental = RentalsDataGridView.Rows[e.RowIndex].Tag as Rental;
            if (rental == null) return;

            Book book = _bookService.GetBookById(rental._book.Id);
            BookInformationForm bookForm = new BookInformationForm(book);
            bookForm.ShowDialog();
        }

        private void RentalsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var clickedColumn = RentalsDataGridView.Columns[e.ColumnIndex];
            if (clickedColumn.Name == "Info")
            {
                var rental = RentalsDataGridView.Rows[e.RowIndex].Tag as Rental;
                if (rental == null) return;

                Book book = _bookService.GetBookById(rental._book.Id);
                BookInformationForm bookForm = new BookInformationForm(book);
                bookForm.ShowDialog();
            }
        }

        private void BrowseBooksButton_Click(object sender, EventArgs e)
        {
            BookBrowsingForm bookBrowsingForm = new BookBrowsingForm(_member, _rentalService, _bookService);
            bookBrowsingForm.Show();
            this.Hide();
            bookBrowsingForm.FormClosed += (s, args) =>
            {
                this.Show();
                PerformSearch();
            };
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Cart.ClearCart();


            this.Close();

        }
    }
}