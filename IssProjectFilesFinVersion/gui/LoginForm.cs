using LRSprojectISS.service;
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
    internal partial class LoginForm : Form
    {
        private readonly MemberService _memberService;
        private readonly BookService _bookService;
        private readonly RentalService _rentalService;

        public LoginForm(MemberService memberService, BookService bookService, RentalService rentalService)
        {
            InitializeComponent();
            _memberService = memberService;
            _bookService = bookService;
            _rentalService = rentalService;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(IdTextBox.Text, out long memberId))
                {
                    MessageBox.Show("Please enter a valid numeric ID.");
                    return;
                }

                string name = NameTextBox.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter your name.");
                    return;
                }

                var member = _memberService.Login(memberId, name);

                UserHomepageForm userForm = new UserHomepageForm(member, _rentalService, _bookService);
                userForm.Show();
                
                this.Hide();
                userForm.FormClosed += (s, args) =>
                {
                    IdTextBox.Text = "";
                    NameTextBox.Text = "";
                    this.Show();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}");
            }
        }
    }
}
