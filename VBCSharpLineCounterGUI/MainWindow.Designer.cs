namespace 代码行数统计工具
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            SelectSln = new LinkLabel();
            ShowTextBox = new TextBox();
            label2 = new Label();
            ShowAllLineLengthTextBox = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 24);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 0;
            label1.Text = "解决方案：";
            // 
            // SelectSln
            // 
            SelectSln.ActiveLinkColor = Color.Black;
            SelectSln.AutoSize = true;
            SelectSln.ForeColor = Color.Black;
            SelectSln.LinkBehavior = LinkBehavior.HoverUnderline;
            SelectSln.LinkColor = Color.Black;
            SelectSln.Location = new Point(105, 24);
            SelectSln.Name = "SelectSln";
            SelectSln.Size = new Size(152, 17);
            SelectSln.TabIndex = 1;
            SelectSln.TabStop = true;
            SelectSln.Text = "解决方案路径（单击选择）";
            // 
            // ShowTextBox
            // 
            ShowTextBox.Font = new Font("Consolas", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ShowTextBox.Location = new Point(31, 57);
            ShowTextBox.Multiline = true;
            ShowTextBox.Name = "ShowTextBox";
            ShowTextBox.ScrollBars = ScrollBars.Vertical;
            ShowTextBox.Size = new Size(205, 267);
            ShowTextBox.TabIndex = 4;
            ShowTextBox.WordWrap = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 7);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 5;
            label2.Text = "共计：";
            // 
            // ShowAllLineLengthTextBox
            // 
            ShowAllLineLengthTextBox.AutoSize = true;
            ShowAllLineLengthTextBox.Location = new Point(53, 7);
            ShowAllLineLengthTextBox.Name = "ShowAllLineLengthTextBox";
            ShowAllLineLengthTextBox.Size = new Size(76, 17);
            ShowAllLineLengthTextBox.TabIndex = 6;
            ShowAllLineLengthTextBox.Text = "99999999行";
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(ShowAllLineLengthTextBox);
            panel1.Location = new Point(31, 559);
            panel1.Name = "panel1";
            panel1.Size = new Size(149, 30);
            panel1.TabIndex = 7;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(410, 598);
            Controls.Add(panel1);
            Controls.Add(ShowTextBox);
            Controls.Add(SelectSln);
            Controls.Add(label1);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VB/C#.NET 代码行数统计工具";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel SelectSln;
        private TextBox ShowTextBox;
        private Label label2;
        private Label ShowAllLineLengthTextBox;
        private Panel panel1;
    }
}
