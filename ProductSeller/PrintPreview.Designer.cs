namespace ProductSeller
{
    partial class PrintPreview
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
            this.txtPrintDoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPrintDoc
            // 
            this.txtPrintDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtPrintDoc.Location = new System.Drawing.Point(12, 12);
            this.txtPrintDoc.Multiline = true;
            this.txtPrintDoc.Name = "txtPrintDoc";
            this.txtPrintDoc.ReadOnly = true;
            this.txtPrintDoc.Size = new System.Drawing.Size(913, 407);
            this.txtPrintDoc.TabIndex = 0;
            // 
            // PrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 455);
            this.Controls.Add(this.txtPrintDoc);
            this.Name = "PrintPreview";
            this.Text = "Print Preview";
            this.Load += new System.EventHandler(this.PrintPreview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrintDoc;
    }
}