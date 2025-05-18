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
    internal partial class UserCartForm : Form
    {
        private readonly Member _member;
        private readonly RentalService _rentalService;
        private readonly BookService _bookService;
        private int _currentPage = 1;
        private const int PageSize = 3;
        private DateTimePicker _dueDatePicker;

        public UserCartForm(Member member, RentalService rentalService, BookService bookService)
        {
            InitializeComponent();
            _member = member;
            _rentalService = rentalService;
            _bookService = bookService;
            InitializeRentalGridColumns();
            PerformSearch();
        }

        private void LoadRentals(IEnumerable<Rental> rentals)
        {
            RentalsDataGridView.Rows.Clear();

            foreach (var rental in rentals)
            {
                int rowIndex = RentalsDataGridView.Rows.Add(
                    rental._book._title,
                    rental._book._author,
                    rental._book._publishDate.Year,
                    rental._dueDate.ToShortDateString(),
                    "Info",
                    "Remove"
                );

                RentalsDataGridView.Rows[rowIndex].Tag = rental;
            }
        }

        private void InitializeRentalGridColumns()
        {
            RentalsDataGridView.Columns.Clear();

            RentalsDataGridView.Columns.Add("Title", "Title");
            RentalsDataGridView.Columns.Add("Author", "Author");
            RentalsDataGridView.Columns.Add("Year", "Year");

            RentalsDataGridView.Columns.Add("DueDate", "Due Date");

            var infoButton = new DataGridViewButtonColumn
            {
                Name = "Info",
                HeaderText = "Info",
                Text = "Info",
                UseColumnTextForButtonValue = true
            };
            RentalsDataGridView.Columns.Add(infoButton);

            var removeButton = new DataGridViewButtonColumn
            {
                Name = "Remove",
                HeaderText = "Remove",
                Text = "Remove",
                UseColumnTextForButtonValue = true
            };
            RentalsDataGridView.Columns.Add(removeButton);

            RentalsDataGridView.AutoGenerateColumns = false;
        }

        private void PerformSearch()
        {
            string titleFilter = SearchTextBox.Text.Trim().ToLower();

            var cartRentals = Cart.GetAllRentals();

            if (!string.IsNullOrWhiteSpace(titleFilter))
            {
                cartRentals = cartRentals
                    .Where(r => r._book._title.ToLower().Contains(titleFilter))
                    .ToList();
            }

            LoadRentals(cartRentals);
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
            bookBrowsingForm.FormClosed += (s, args) => this.Show();
        }

        private void UserCartForm_Load(object sender, EventArgs e)
        {
            RentalsDataGridView.Columns.Clear();
            RentalsDataGridView.AllowUserToAddRows = false;

            RentalsDataGridView.Columns.Add("Title", "Title");
            RentalsDataGridView.Columns.Add("Author", "Author");
            RentalsDataGridView.Columns.Add("Year", "Year");

            // Due Date column as custom DateTimePicker
            var dueDateCol = new DataGridViewTextBoxColumn();
            dueDateCol.Name = "DueDate";
            dueDateCol.HeaderText = "Due Date";
            RentalsDataGridView.Columns.Add(dueDateCol);

            var infoBtn = new DataGridViewButtonColumn
            {
                Name = "Info",
                Text = "Info",
                UseColumnTextForButtonValue = true
            };
            RentalsDataGridView.Columns.Add(infoBtn);

            var removeBtn = new DataGridViewButtonColumn
            {
                Name = "Remove",
                Text = "Remove",
                UseColumnTextForButtonValue = true
            };
            RentalsDataGridView.Columns.Add(removeBtn);

            LoadRentals(Cart.GetAllRentals());
        }

        private void RentalsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var clickedColumn = RentalsDataGridView.Columns[e.ColumnIndex];
            var rental = RentalsDataGridView.Rows[e.RowIndex].Tag as Rental;

            if (clickedColumn.Name == "Info" && rental != null)
            {
                var bookForm = new BookInformationForm(rental._book);
                bookForm.ShowDialog();
            }

            if (clickedColumn.Name == "Remove" && rental != null)
            {
                Cart.RemoveFromCart(rental._book.Id);
                LoadRentals(Cart.GetAllRentals());
            }
        }

        private void RentalsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == RentalsDataGridView.Columns["DueDate"].Index && e.RowIndex >= 0)
            {
                _dueDatePicker = new DateTimePicker();
                _dueDatePicker.Format = DateTimePickerFormat.Short;
                _dueDatePicker.Visible = true;

                var cellRect = RentalsDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                _dueDatePicker.Bounds = cellRect;
                _dueDatePicker.Value = DateTime.Parse(RentalsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                _dueDatePicker.CloseUp += (s, args) =>
                {
                    RentalsDataGridView.Controls.Remove(_dueDatePicker);
                };

                _dueDatePicker.ValueChanged += (s, args) =>
                {
                    RentalsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _dueDatePicker.Value.ToShortDateString();

                    var rental = RentalsDataGridView.Rows[e.RowIndex].Tag as Rental;
                    if (rental != null)
                    {
                        rental._dueDate = _dueDatePicker.Value;
                    }
                };

                RentalsDataGridView.Controls.Add(_dueDatePicker);
                _dueDatePicker.BringToFront();
                _dueDatePicker.Focus();
            }
        }

        private void RentBooksButton_Click(object sender, EventArgs e)
        {
            List<string> failedBooks = new List<string>();

            foreach (var rental in Cart.GetAllRentals())
            {
                try
                {
                    _rentalService.RentBook(_member.Id, rental._book, rental._dueDate);
                }
                catch (Exception ex)
                {

                    failedBooks.Add(rental._book._title);
                }
            }

            Cart.ClearCart();


            if (failedBooks.Any())
            {
                string message = "Some books could not be rented due to no available copies:\n\n" +
                                 string.Join("\n", failedBooks);
                MessageBox.Show(message, "Rental Issues", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("All books rented successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            PerformSearch();
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}