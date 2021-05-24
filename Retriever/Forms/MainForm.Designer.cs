namespace Retriever.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._UsernameInput = new System.Windows.Forms.TextBox();
            this._HeadingImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._CheckButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this._HeadingText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._HeadingImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _UsernameInput
            // 
            this._UsernameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._UsernameInput.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._UsernameInput.Location = new System.Drawing.Point(12, 62);
            this._UsernameInput.Name = "_UsernameInput";
            this._UsernameInput.PlaceholderText = "Username";
            this._UsernameInput.Size = new System.Drawing.Size(326, 27);
            this._UsernameInput.TabIndex = 0;
            this._UsernameInput.WordWrap = false;
            // 
            // _HeadingImage
            // 
            this._HeadingImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._HeadingImage.Image = global::Retriever.Images.Header;
            this._HeadingImage.Location = new System.Drawing.Point(0, 0);
            this._HeadingImage.Name = "_HeadingImage";
            this._HeadingImage.Size = new System.Drawing.Size(350, 42);
            this._HeadingImage.TabIndex = 1;
            this._HeadingImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this._CheckButton);
            this.panel1.Location = new System.Drawing.Point(0, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 41);
            this.panel1.TabIndex = 2;
            // 
            // _CheckButton
            // 
            this._CheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._CheckButton.Enabled = false;
            this._CheckButton.Location = new System.Drawing.Point(263, 9);
            this._CheckButton.Name = "_CheckButton";
            this._CheckButton.Size = new System.Drawing.Size(75, 23);
            this._CheckButton.TabIndex = 1;
            this._CheckButton.Text = "&Check";
            this._CheckButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.panel2.Location = new System.Drawing.Point(0, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 1);
            this.panel2.TabIndex = 3;
            // 
            // _HeadingText
            // 
            this._HeadingText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._HeadingText.AutoSize = true;
            this._HeadingText.BackColor = System.Drawing.Color.Transparent;
            this._HeadingText.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._HeadingText.ForeColor = System.Drawing.Color.White;
            this._HeadingText.Location = new System.Drawing.Point(12, 9);
            this._HeadingText.Name = "_HeadingText";
            this._HeadingText.Size = new System.Drawing.Size(146, 23);
            this._HeadingText.TabIndex = 4;
            this._HeadingText.Text = "Enter a Username";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 150);
            this.Controls.Add(this._HeadingText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._HeadingImage);
            this.Controls.Add(this._UsernameInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retriever";
            ((System.ComponentModel.ISupportInitialize)(this._HeadingImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _UsernameInput;
        private System.Windows.Forms.PictureBox _HeadingImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _CheckButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label _HeadingText;
    }
}