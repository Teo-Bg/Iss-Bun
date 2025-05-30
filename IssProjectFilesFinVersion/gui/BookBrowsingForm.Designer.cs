namespace LRSprojectISS.gui
{
    partial class BookBrowsingForm
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
            Genres = new DataGridViewTextBoxColumn();
            Avalability = new DataGridViewTextBoxColumn();
            Rent = new DataGridViewButtonColumn();
            PrevButton = new Button();
            NextButton = new Button();
            label2 = new Label();
            GoToCartButton = new Button();
            GoBackButton = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)RentalsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 36);
            label1.Name = "label1";
            label1.Size = new Size(111, 45);
            label1.TabIndex = 0;
            label1.Text = "Hello, ";
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(39, 231);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(122, 64);
            SearchButton.TabIndex = 1;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(167, 244);
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
            RentalsDataGridView.Columns.AddRange(new DataGridViewColumn[] { Title, Author, Year, Genres, Avalability, Rent });
            RentalsDataGridView.Location = new Point(39, 311);
            RentalsDataGridView.MultiSelect = false;
            RentalsDataGridView.Name = "RentalsDataGridView";
            RentalsDataGridView.ReadOnly = true;
            RentalsDataGridView.RowHeadersVisible = false;
            RentalsDataGridView.RowHeadersWidth = 82;
            RentalsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RentalsDataGridView.Size = new Size(1581, 624);
            RentalsDataGridView.TabIndex = 3;
            RentalsDataGridView.CellClick += RentalsDataGridView_CellClick;
            RentalsDataGridView.CellContentClick += RentalsDataGridView_CellContentClick;
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
            // Genres
            // 
            Genres.HeaderText = "Genres";
            Genres.MinimumWidth = 10;
            Genres.Name = "Genres";
            Genres.ReadOnly = true;
            Genres.Width = 200;
            // 
            // Avalability
            // 
            Avalability.HeaderText = "Avalability";
            Avalability.MinimumWidth = 10;
            Avalability.Name = "Avalability";
            Avalability.ReadOnly = true;
            Avalability.Width = 200;
            // 
            // Rent
            // 
            Rent.HeaderText = "Rent";
            Rent.MinimumWidth = 10;
            Rent.Name = "Rent";
            Rent.ReadOnly = true;
            Rent.Width = 200;
            // 
            // PrevButton
            // 
            PrevButton.Location = new Point(1516, 259);
            PrevButton.Name = "PrevButton";
            PrevButton.Size = new Size(55, 46);
            PrevButton.TabIndex = 4;
            PrevButton.Text = "<";
            PrevButton.UseVisualStyleBackColor = true;
            PrevButton.Click += PrevButton_Click;
            // 
            // NextButton
            // 
            NextButton.Location = new Point(1568, 259);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(55, 46);
            NextButton.TabIndex = 5;
            NextButton.Text = ">";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(684, 147);
            label2.Name = "label2";
            label2.Size = new Size(287, 59);
            label2.TabIndex = 7;
            label2.Text = "Browse books";
            // 
            // GoToCartButton
            // 
            GoToCartButton.Location = new Point(1335, 1012);
            GoToCartButton.Name = "GoToCartButton";
            GoToCartButton.Size = new Size(285, 85);
            GoToCartButton.TabIndex = 8;
            GoToCartButton.Text = "Go to cart";
            GoToCartButton.UseVisualStyleBackColor = true;
            GoToCartButton.Click += GoToCartButton_Click;
            // 
            // GoBackButton
            // 
            GoBackButton.Location = new Point(39, 1012);
            GoBackButton.Name = "GoBackButton";
            GoBackButton.Size = new Size(230, 93);
            GoBackButton.TabIndex = 9;
            GoBackButton.Text = "Go Back";
            GoBackButton.UseVisualStyleBackColor = true;
            GoBackButton.Click += GoBackButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-14, 81);
            label3.Name = "label3";
            label3.Size = new Size(1944, 32);
            label3.TabIndex = 10;
            label3.Text = "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // BookBrowsingForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1655, 1143);
            Controls.Add(label3);
            Controls.Add(GoBackButton);
            Controls.Add(GoToCartButton);
            Controls.Add(label2);
            Controls.Add(NextButton);
            Controls.Add(PrevButton);
            Controls.Add(RentalsDataGridView);
            Controls.Add(SearchTextBox);
            Controls.Add(SearchButton);
            Controls.Add(label1);
            Name = "BookBrowsingForm";
            Text = "BookBrowsingForm";
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
        private Label label2;
        private Button GoToCartButton;
        private Button GoBackButton;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Year;
        private DataGridViewTextBoxColumn Genres;
        private DataGridViewTextBoxColumn Avalability;
        private DataGridViewButtonColumn Rent;
        private Label label3;
    }
}