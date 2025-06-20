﻿namespace LRSprojectISS.gui
{
    partial class UserHomepageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            SearchButton = new Button();
            SearchTextBox = new TextBox();
            RentalsDataGridView = new DataGridView();
            Title = new DataGridViewTextBoxColumn();
            Author = new DataGridViewTextBoxColumn();
            Year = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            Info = new DataGridViewButtonColumn();
            PrevButton = new Button();
            NextButton = new Button();
            StatusComboBox = new ComboBox();
            BrowseBooksButton = new Button();
            LogoutButton = new Button();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)RentalsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 49);
            label1.Name = "label1";
            label1.Size = new Size(111, 45);
            label1.TabIndex = 0;
            label1.Text = "Hello, ";
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(39, 247);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(122, 64);
            SearchButton.TabIndex = 1;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(167, 260);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(643, 39);
            SearchTextBox.TabIndex = 2;
            // 
            // RentalsDataGridView
            // 
            RentalsDataGridView.AllowUserToAddRows = false;
            RentalsDataGridView.AllowUserToDeleteRows = false;
            RentalsDataGridView.AllowUserToResizeColumns = false;
            RentalsDataGridView.AllowUserToResizeRows = false;
            RentalsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RentalsDataGridView.Columns.AddRange(new DataGridViewColumn[] { Title, Author, Year, Status, DueDate, Info });
            RentalsDataGridView.Location = new Point(39, 327);
            RentalsDataGridView.MultiSelect = false;
            RentalsDataGridView.Name = "RentalsDataGridView";
            RentalsDataGridView.ReadOnly = true;
            RentalsDataGridView.RowHeadersVisible = false;
            RentalsDataGridView.RowHeadersWidth = 82;
            RentalsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RentalsDataGridView.Size = new Size(1581, 617);
            RentalsDataGridView.TabIndex = 3;
            RentalsDataGridView.CellContentClick += RentalsDataGridView_CellContentClick;
            RentalsDataGridView.RowHeaderMouseClick += RentalsDataGridView_RowHeaderMouseClick;
            // 
            // Title
            // 
            Title.HeaderText = "Title";
            Title.MinimumWidth = 10;
            Title.Name = "Title";
            Title.ReadOnly = true;
            Title.Width = 200;
            // 
            // Author
            // 
            Author.HeaderText = "Author";
            Author.MinimumWidth = 10;
            Author.Name = "Author";
            Author.ReadOnly = true;
            Author.Width = 200;
            // 
            // Year
            // 
            Year.HeaderText = "Year";
            Year.MinimumWidth = 10;
            Year.Name = "Year";
            Year.ReadOnly = true;
            Year.Width = 200;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 10;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 200;
            // 
            // DueDate
            // 
            DueDate.HeaderText = "Due Date";
            DueDate.MinimumWidth = 10;
            DueDate.Name = "DueDate";
            DueDate.ReadOnly = true;
            DueDate.Width = 200;
            // 
            // Info
            // 
            Info.HeaderText = "Info";
            Info.MinimumWidth = 10;
            Info.Name = "Info";
            Info.ReadOnly = true;
            Info.UseColumnTextForButtonValue = true;
            Info.Width = 200;
            // 
            // PrevButton
            // 
            PrevButton.Location = new Point(1516, 275);
            PrevButton.Name = "PrevButton";
            PrevButton.Size = new Size(55, 46);
            PrevButton.TabIndex = 4;
            PrevButton.Text = "<";
            PrevButton.UseVisualStyleBackColor = true;
            PrevButton.Click += PrevButton_Click;
            // 
            // NextButton
            // 
            NextButton.Location = new Point(1568, 275);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(55, 46);
            NextButton.TabIndex = 5;
            NextButton.Text = ">";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // StatusComboBox
            // 
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Items.AddRange(new object[] { "Status", "Pending", "Returned", "Overdue" });
            StatusComboBox.Location = new Point(816, 260);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(264, 40);
            StatusComboBox.TabIndex = 6;
            // 
            // BrowseBooksButton
            // 
            BrowseBooksButton.Location = new Point(1380, 1004);
            BrowseBooksButton.Name = "BrowseBooksButton";
            BrowseBooksButton.Size = new Size(243, 92);
            BrowseBooksButton.TabIndex = 7;
            BrowseBooksButton.Text = "Browse Books";
            BrowseBooksButton.UseVisualStyleBackColor = true;
            BrowseBooksButton.Click += BrowseBooksButton_Click;
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(1398, 36);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(222, 58);
            LogoutButton.TabIndex = 8;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-154, 94);
            label3.Name = "label3";
            label3.Size = new Size(1944, 32);
            label3.TabIndex = 11;
            label3.Text = "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(645, 159);
            label2.Name = "label2";
            label2.Size = new Size(346, 59);
            label2.TabIndex = 13;
            label2.Text = "My rented books";
            // 
            // UserHomepageForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1655, 1143);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(LogoutButton);
            Controls.Add(BrowseBooksButton);
            Controls.Add(StatusComboBox);
            Controls.Add(NextButton);
            Controls.Add(PrevButton);
            Controls.Add(RentalsDataGridView);
            Controls.Add(SearchTextBox);
            Controls.Add(SearchButton);
            Controls.Add(label1);
            Name = "UserHomepageForm";
            Text = "UserHomepageForm";
            ((System.ComponentModel.ISupportInitialize)RentalsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button SearchButton;
        private TextBox SearchTextBox;
        private DataGridView RentalsDataGridView;
        private Button PrevButton;
        private Button NextButton;
        private ComboBox StatusComboBox;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Year;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn DueDate;
        private DataGridViewButtonColumn Info;
        private Button BrowseBooksButton;
        private Button LogoutButton;
        private Label label3;
        private Label label2;
    }
}