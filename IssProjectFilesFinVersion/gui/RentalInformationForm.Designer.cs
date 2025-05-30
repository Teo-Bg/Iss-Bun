namespace LRSprojectISS.gui
{
    partial class RentalInformationForm
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
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 40);
            label1.Name = "label1";
            label1.Size = new Size(75, 32);
            label1.TabIndex = 0;
            label1.Text = "Hello,";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(633, 163);
            label2.Name = "label2";
            label2.Size = new Size(212, 32);
            label2.TabIndex = 1;
            label2.Text = "Rental Information";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(39, 243);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(510, 694);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // RentalInformationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1655, 1143);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RentalInformationForm";
            Text = "RentalInformationForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}