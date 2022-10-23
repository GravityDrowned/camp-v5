namespace camp_v5
{
    partial class ModalAppContainer
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
            this.webViewModal = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webViewModal)).BeginInit();
            this.SuspendLayout();
            // 
            // webViewModal
            // 
            this.webViewModal.AllowExternalDrop = true;
            this.webViewModal.CreationProperties = null;
            this.webViewModal.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewModal.Location = new System.Drawing.Point(12, 12);
            this.webViewModal.Name = "webViewModal";
            this.webViewModal.Size = new System.Drawing.Size(776, 426);
            this.webViewModal.Source = new System.Uri("https://learn.microsoft.com/", System.UriKind.Absolute);
            this.webViewModal.TabIndex = 0;
            this.webViewModal.ZoomFactor = 1D;
            this.webViewModal.Click += new System.EventHandler(this.webViewModal_Click);
            // 
            // ModalAppContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webViewModal);
            this.Name = "ModalAppContainer";
            this.Text = "ModalAppContainer";
            ((System.ComponentModel.ISupportInitialize)(this.webViewModal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewModal;
    }
}