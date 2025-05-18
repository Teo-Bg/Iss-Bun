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
    internal partial class BookBrowsingForm : Form
    {
        private readonly Member _member;
        private readonly RentalService _rentalService;
        private readonly BookService _bookService;
        private int _currentPage = 1;
        private const int PageSize = 10;

        public BookBrowsingForm(Member member, RentalService rentalService, BookService bookService)
        {
            InitializeComponent();
            _member = member;
            _rentalService = rentalService;
            _bookService = bookService;
            PerformSearch();
        }

        private void LoadBooks(IEnumerable<Book> books)
        {
            //var rentals = _rentalService.SearchRentals(_member.Id, _currentPage, PageSize);
            RentalsDataGridView.Rows.Clear();

           

            foreach (var book in books)
            {
                string genresString = string.Join(", ", Enum.GetValues(typeof(Genre))
                .Cast<Genre>()
                .Where(g => g != Genre.None && book._genres.HasFlag(g))
                .Select(g => $"[{g}]"));

                int activeRentals = _rentalService.GetActiveRentalCountForBook(book.Id); // Make sure _rentalRepo is accessible
                int availableCopies = book._copies - activeRentals;
                string availability = $"{availableCopies} / {book._copies}";

                int rowIndex = RentalsDataGridView.Rows.Add(
                    book._title,
                    book._author,
                    book._publishDate.Year,
                    genresString,
                    availability,
                    "i"
                );
                RentalsDataGridView.Rows[rowIndex].Tag = book;
            }
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


            var books = _bookService.SearchBooks(
                _currentPage,
                PageSize,
                title,
                author,
                genre
            );

            LoadBooks(books);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void RentalsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("1");
            if (e.RowIndex < 0)
                return;

            var book = RentalsDataGridView.Rows[e.RowIndex].Tag as Book;
            if (book == null) return;


            BookRentForm bookForm = new BookRentForm(book, _member);
            bookForm.ShowDialog();
            PerformSearch();
        }

        private void RentalsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var clickedColumn = RentalsDataGridView.Columns[e.ColumnIndex];
            if (clickedColumn.Name == "Info")
            {

                var book = RentalsDataGridView.Rows[e.RowIndex].Tag as Book;
                if (book == null) return;

                BookRentForm bookForm = new BookRentForm(book, _member);
                bookForm.ShowDialog();
                PerformSearch();
            }
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GoToCartButton_Click(object sender, EventArgs e)
        {
            UserCartForm userCartForm = new UserCartForm(_member, _rentalService, _bookService);
            userCartForm.Show();
            this.Hide();
            userCartForm.FormClosed += (s, args) =>
            {
                this.Show();
                PerformSearch();
            };
        }
    }
}
