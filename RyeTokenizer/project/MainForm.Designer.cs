namespace LollipopUI
{
    partial class MainForm
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
			this.btn_tokenize = new LollipopButton();
			this.lollipopTextBox1 = new LollipopTextBox();
			this.browse_folder = new LollipopFolderInPut();
			this.txtbox_input = new LollipopTextBox();
			this.label_rye = new LollipopLabel();
			this.SuspendLayout();
			// 
			// btn_tokenize
			// 
			this.btn_tokenize.BackColor = System.Drawing.Color.Transparent;
			this.btn_tokenize.BGColor = " #2196f3";
			this.btn_tokenize.FontColor = "#f5f5f5";
			this.btn_tokenize.Location = new System.Drawing.Point(484, 82);
			this.btn_tokenize.Name = "btn_tokenize";
			this.btn_tokenize.Size = new System.Drawing.Size(143, 41);
			this.btn_tokenize.TabIndex = 5;
			this.btn_tokenize.Text = "Tokenizing";
			// 
			// lollipopTextBox1
			// 
			this.lollipopTextBox1.FocusedColor = " #2196f3";
			this.lollipopTextBox1.FontColor = "#9e9e9e";
			this.lollipopTextBox1.IsEnabled = true;
			this.lollipopTextBox1.Location = new System.Drawing.Point(327, 129);
			this.lollipopTextBox1.MaxLength = 32767;
			this.lollipopTextBox1.Multiline = true;
			this.lollipopTextBox1.Name = "lollipopTextBox1";
			this.lollipopTextBox1.ReadOnly = false;
			this.lollipopTextBox1.Size = new System.Drawing.Size(300, 300);
			this.lollipopTextBox1.TabIndex = 4;
			this.lollipopTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
			this.lollipopTextBox1.UseSystemPasswordChar = false;
			// 
			// browse_folder
			// 
			this.browse_folder.FocusedColor = " #2196f3";
			this.browse_folder.FontColor = "#9e9e9e";
			this.browse_folder.IsEnabled = true;
			this.browse_folder.Location = new System.Drawing.Point(21, 99);
			this.browse_folder.MaxLength = 32767;
			this.browse_folder.Name = "browse_folder";
			this.browse_folder.ReadOnly = false;
			this.browse_folder.Size = new System.Drawing.Size(300, 24);
			this.browse_folder.TabIndex = 2;
			this.browse_folder.Text = "Please insert folder";
			this.browse_folder.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
			this.browse_folder.UseSystemPasswordChar = false;
			// 
			// txtbox_input
			// 
			this.txtbox_input.FocusedColor = " #2196f3";
			this.txtbox_input.FontColor = "#9e9e9e";
			this.txtbox_input.IsEnabled = true;
			this.txtbox_input.Location = new System.Drawing.Point(21, 129);
			this.txtbox_input.MaxLength = 32767;
			this.txtbox_input.Multiline = true;
			this.txtbox_input.Name = "txtbox_input";
			this.txtbox_input.ReadOnly = false;
			this.txtbox_input.Size = new System.Drawing.Size(300, 300);
			this.txtbox_input.TabIndex = 1;
			this.txtbox_input.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtbox_input.UseSystemPasswordChar = false;
			// 
			// label_rye
			// 
			this.label_rye.AutoSize = true;
			this.label_rye.BackColor = System.Drawing.Color.Transparent;
			this.label_rye.Font = new System.Drawing.Font("Forte", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_rye.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label_rye.Location = new System.Drawing.Point(12, 9);
			this.label_rye.Name = "label_rye";
			this.label_rye.Size = new System.Drawing.Size(295, 52);
			this.label_rye.TabIndex = 0;
			this.label_rye.Text = "Rye Tokenizer";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(634, 441);
			this.Controls.Add(this.btn_tokenize);
			this.Controls.Add(this.lollipopTextBox1);
			this.Controls.Add(this.browse_folder);
			this.Controls.Add(this.txtbox_input);
			this.Controls.Add(this.label_rye);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TestForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }



		#endregion

		private LollipopLabel label_rye;
		private LollipopTextBox txtbox_input;
		private LollipopFolderInPut browse_folder;
		private LollipopTextBox lollipopTextBox1;
		private LollipopButton btn_tokenize;
	}
}

