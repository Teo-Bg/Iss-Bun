namespace LRSprojectISS.gui
{
    partial class LoginForm
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
            LoginButton = new Button();
            Welcome = new Label();
            label1 = new Label();
            label2 = new Label();
            IdTextBox = new TextBox();
            NameTextBox = new TextBox();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(477, 441);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(246, 79);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // Welcome
            // 
            Welcome.AutoSize = true;
            Welcome.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Welcome.Location = new Point(506, 85);
            Welcome.Name = "Welcome";
            Welcome.Size = new Size(185, 50);
            Welcome.TabIndex = 1;
            Welcome.Text = "Welcome!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(377, 222);
            label1.Name = "label1";
            label1.Size = new Size(84, 32);
            label1.TabIndex = 2;
            label1.Text = "LRS Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(377, 309);
            label2.Name = "label2";
            label2.Size = new Size(83, 32);
            label2.TabIndex = 3;
            label2.Text = "Name:";
            // 
            // IdTextBox
            // 
            IdTextBox.Location = new Point(496, 222);
            IdTextBox.Name = "IdTextBox";
            IdTextBox.Size = new Size(299, 39);
            IdTextBox.TabIndex = 4;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(496, 309);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(299, 39);
            NameTextBox.TabIndex = 5;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 635);
            Controls.Add(NameTextBox);
            Controls.Add(IdTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Welcome);
            Controls.Add(LoginButton);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginButton;
        private Label Welcome;
        private Label label1;
        private Label label2;
        private TextBox IdTextBox;
        private TextBox NameTextBox;
    }
}