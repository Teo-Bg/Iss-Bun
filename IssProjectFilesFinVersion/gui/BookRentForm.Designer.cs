namespace LRSprojectISS.gui
{
    partial class BookRentForm
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
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            DescriptionTextBox = new TextBox();
            TitleLabel = new Label();
            AuthorLabel = new Label();
            YearLabel = new Label();
            GenreLabel = new Label();
            GoBackButton = new Button();
            label7 = new Label();
            ReturnTimePicker = new DateTimePicker();
            AddToCartButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 46);
            label1.Name = "label1";
            label1.Size = new Size(75, 32);
            label1.TabIndex = 0;
            label1.Text = "Hello,";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(47, 248);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(585, 720);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(616, 138);
            label2.Name = "label2";
            label2.Size = new Size(200, 32);
            label2.TabIndex = 2;
            label2.Text = "Book Information";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(675, 257);
            label3.Name = "label3";
            label3.Size = new Size(65, 32);
            label3.TabIndex = 3;
            label3.Text = "Title:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(648, 335);
            label4.Name = "label4";
            label4.Size = new Size(92, 32);
            label4.TabIndex = 4;
            label4.Text = "Author:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(677, 408);
            label5.Name = "label5";
            label5.Size = new Size(63, 32);
            label5.TabIndex = 5;
            label5.Text = "Year:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(657, 477);
            label6.Name = "label6";
            label6.Size = new Size(83, 32);
            label6.TabIndex = 6;
            label6.Text = "Genre:";
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(657, 554);
            DescriptionTextBox.Multiline = true;
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(969, 414);
            DescriptionTextBox.TabIndex = 7;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(781, 257);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(78, 32);
            TitleLabel.TabIndex = 8;
            TitleLabel.Text = "label7";
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Location = new Point(781, 335);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(78, 32);
            AuthorLabel.TabIndex = 9;
            AuthorLabel.Text = "label8";
            // 
            // YearLabel
            // 
            YearLabel.AutoSize = true;
            YearLabel.Location = new Point(781, 408);
            YearLabel.Name = "YearLabel";
            YearLabel.Size = new Size(78, 32);
            YearLabel.TabIndex = 10;
            YearLabel.Text = "label9";
            // 
            // GenreLabel
            // 
            GenreLabel.AutoSize = true;
            GenreLabel.Location = new Point(781, 477);
            GenreLabel.Name = "GenreLabel";
            GenreLabel.Size = new Size(91, 32);
            GenreLabel.TabIndex = 11;
            GenreLabel.Text = "label10";
            // 
            // GoBackButton
            // 
            GoBackButton.Location = new Point(47, 1025);
            GoBackButton.Name = "GoBackButton";
            GoBackButton.Size = new Size(288, 75);
            GoBackButton.TabIndex = 12;
            GoBackButton.Text = "Go back";
            GoBackButton.UseVisualStyleBackColor = true;
            GoBackButton.Click += GoBackButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(750, 1046);
            label7.Name = "label7";
            label7.Size = new Size(120, 32);
            label7.TabIndex = 13;
            label7.Text = "Due Date:";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // ReturnTimePicker
            // 
            ReturnTimePicker.Location = new Point(876, 1046);
            ReturnTimePicker.Name = "ReturnTimePicker";
            ReturnTimePicker.Size = new Size(400, 39);
            ReturnTimePicker.TabIndex = 14;
            // 
            // AddToCartButton
            // 
            AddToCartButton.Location = new Point(1300, 1033);
            AddToCartButton.Name = "AddToCartButton";
            AddToCartButton.Size = new Size(296, 69);
            AddToCartButton.TabIndex = 15;
            AddToCartButton.Text = "Rent Book";
            AddToCartButton.UseVisualStyleBackColor = true;
            AddToCartButton.Click += AddToCartButton_Click;
            // 
            // BookRentForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1655, 1143);
            Controls.Add(AddToCartButton);
            Controls.Add(ReturnTimePicker);
            Controls.Add(label7);
            Controls.Add(GoBackButton);
            Controls.Add(GenreLabel);
            Controls.Add(YearLabel);
            Controls.Add(AuthorLabel);
            Controls.Add(TitleLabel);
            Controls.Add(DescriptionTextBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "BookRentForm";
            Text = "BookRentForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox DescriptionTextBox;
        private Label TitleLabel;
        private Label AuthorLabel;
        private Label YearLabel;
        private Label GenreLabel;
        private Button GoBackButton;
        private Label label7;
        private DateTimePicker ReturnTimePicker;
        private Button AddToCartButton;
    }
}