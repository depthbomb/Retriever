
namespace Retriever.Forms
{
    partial class ResultsForm
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
            this._ResultsList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // _ResultsList
            // 
            this._ResultsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ResultsList.FullRowSelect = true;
            this._ResultsList.GridLines = true;
            this._ResultsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._ResultsList.HideSelection = false;
            this._ResultsList.Location = new System.Drawing.Point(13, 13);
            this._ResultsList.MultiSelect = false;
            this._ResultsList.Name = "_ResultsList";
            this._ResultsList.Size = new System.Drawing.Size(578, 417);
            this._ResultsList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this._ResultsList.TabIndex = 0;
            this._ResultsList.UseCompatibleStateImageBehavior = false;
            this._ResultsList.View = System.Windows.Forms.View.Details;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 442);
            this.Controls.Add(this._ResultsList);
            this.MinimizeBox = false;
            this.Name = "ResultsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Retriever Results";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _ResultsList;
    }
}