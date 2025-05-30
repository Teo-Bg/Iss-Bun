using LRSprojectISS.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRSprojectISS.gui
{
    internal partial class BookRentForm : Form
    {
        private readonly Book _book;
        private readonly Member _member;

        public BookRentForm(Book book, Member member)
        {
            _book = book;
            _member = member;
            InitializeComponent();
            LoadBookDetails();
        }

        private void LoadBookDetails()
        {
            TitleLabel.Text = _book._title;
            AuthorLabel.Text = _book._author;
            YearLabel.Text = _book._publishDate.Year.ToString();
            GenreLabel.Text = GetFormattedGenres(_book._genres);
            DescriptionTextBox.Text = _book._description;
        }

        private string GetFormattedGenres(Genre genres)
        {
            if (genres == Genre.None)
                return "None";

            var selectedGenres = Enum.GetValues(typeof(Genre))
                .Cast<Genre>()
                .Where(g => g != Genre.None && genres.HasFlag(g))
                .Select(g => $"[{g}]");

            return string.Join(", ", selectedGenres);
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            DateTime rentDate = DateTime.Now;
            DateTime dueDate = ReturnTimePicker.Value;

            var rental = new Rental(_member, _book, rentDate, dueDate, null);

            Cart.AddToCart(rental);

            MessageBox.Show("Book added to cart successfully!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
