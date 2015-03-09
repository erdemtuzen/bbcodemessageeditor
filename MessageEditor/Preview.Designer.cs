namespace MessageEditor
{
    partial class Preview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.WebBrowserPreview = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WebBrowserPreview
            // 
            this.WebBrowserPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowserPreview.Location = new System.Drawing.Point(0, 0);
            this.WebBrowserPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowserPreview.Name = "WebBrowserPreview";
            this.WebBrowserPreview.Size = new System.Drawing.Size(624, 442);
            this.WebBrowserPreview.TabIndex = 0;
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.WebBrowserPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Preview";
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.Preview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebBrowserPreview;
    }
}