namespace MailFolderOutlookAddin.UI
{
    partial class MailFolderViewForm
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
            this.mailFolderView = new MailFolderView();
            this.SuspendLayout();
            // 
            // mailFolderView
            // 
            this.mailFolderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mailFolderView.Location = new System.Drawing.Point(0, 0);
            this.mailFolderView.Name = "mailFolderView";
            this.mailFolderView.Size = new System.Drawing.Size(431, 553);
            this.mailFolderView.TabIndex = 0;
            // 
            // MailFolderViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(431, 553);
            this.Controls.Add(this.mailFolderView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MailFolderViewForm";
            this.Text = "MailFolderViewForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MailFolderViewForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private MailFolderView mailFolderView;
    }
}