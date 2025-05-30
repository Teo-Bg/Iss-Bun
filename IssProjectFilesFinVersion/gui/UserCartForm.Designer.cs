namespace LRSprojectISS.gui
{
    partial class UserCartForm
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
            StatusComboBox = new ComboBox();
            RentalsDataGridView = new DataGridView();
            RentBooksButton = new Button();
            GoBackButton = new Button();
            label3 = new Label();
            label2 = new Label();
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
            SearchButton.Location = new Point(39, 229);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(122, 64);
            SearchButton.TabIndex = 1;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(167, 242);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(643, 39);
            SearchTextBox.TabIndex = 2;
            // 
            // StatusComboBox
            // 
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Items.AddRange(new object[] { "Status", "Pending", "Returned", "Overdue" });
            StatusComboBox.Location = new Point(816, 242);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(264, 40);
            StatusComboBox.TabIndex = 6;
            // 
            // RentalsDataGridView
            // 
            RentalsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RentalsDataGridView.Location = new Point(39, 317);
            RentalsDataGridView.Name = "RentalsDataGridView";
            RentalsDataGridView.RowHeadersWidth = 82;
            RentalsDataGridView.Size = new Size(1584, 641);
            RentalsDataGridView.TabIndex = 8;
            RentalsDataGridView.CellClick += RentalsDataGridView_CellClick;
            RentalsDataGridView.CellDoubleClick += RentalsDataGridView_CellDoubleClick;
            // 
            // RentBooksButton
            // 
            RentBooksButton.Location = new Point(1300, 993);
            RentBooksButton.Name = "RentBooksButton";
            RentBooksButton.Size = new Size(323, 91);
            RentBooksButton.TabIndex = 9;
            RentBooksButton.Text = "Rent Books";
            RentBooksButton.UseVisualStyleBackColor = true;
            RentBooksButton.Click += RentBooksButton_Click;
            // 
            // GoBackButton
            // 
            GoBackButton.Location = new Point(39, 993);
            GoBackButton.Name = "GoBackButton";
            GoBackButton.Size = new Size(272, 95);
            GoBackButton.TabIndex = 10;
            GoBackButton.Text = "Go Back";
            GoBackButton.UseVisualStyleBackColor = true;
            GoBackButton.Click += GoBackButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-21, 81);
            label3.Name = "label3";
            label3.Size = new Size(1944, 32);
            label3.TabIndex = 11;
            label3.Text = "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(680, 144);
            label2.Name = "label2";
            label2.Size = new Size(257, 59);
            label2.TabIndex = 12;
            label2.Text = "My rent cart";
            // 
            // UserCartForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1655, 1143);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(GoBackButton);
            Controls.Add(RentBooksButton);
            Controls.Add(RentalsDataGridView);
            Controls.Add(StatusComboBox);
            Controls.Add(SearchTextBox);
            Controls.Add(SearchButton);
            Controls.Add(label1);
            Name = "UserCartForm";
            Text = "UserCartForm";
            Load += UserCartForm_Load;
            ((System.ComponentModel.ISupportInitialize)RentalsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button SearchButton;
        private TextBox SearchTextBox;
        private ComboBox StatusComboBox;
        private DataGridView RentalsDataGridView;
        private Button RentBooksButton;
        private Button GoBackButton;
        private Label label3;
        private Label label2;
    }
}