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
    internal partial class BookInformationForm : Form
    {
        private readonly Book _book;

        public BookInformationForm(Book book)
        {
            _book = book;
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
    }
}
