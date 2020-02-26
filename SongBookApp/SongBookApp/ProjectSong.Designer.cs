namespace SongBookApp
{
    partial class ProjectSong
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
            this.textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textLabel
            // 
            this.textLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLabel.Location = new System.Drawing.Point(0, 0);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(800, 450);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "paragraphText";
            this.textLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textLabel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ProjectSong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectSong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProjectSong_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label textLabel;
    }
}