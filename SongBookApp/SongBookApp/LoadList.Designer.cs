namespace SongBookApp
{
    partial class LoadList
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
            this.songLists = new System.Windows.Forms.ListBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // songLists
            // 
            this.songLists.FormattingEnabled = true;
            this.songLists.Location = new System.Drawing.Point(12, 12);
            this.songLists.Name = "songLists";
            this.songLists.Size = new System.Drawing.Size(184, 238);
            this.songLists.TabIndex = 0;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(46, 256);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(121, 23);
            this.selectButton.TabIndex = 1;
            this.selectButton.Text = "Load songlist";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // LoadList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 289);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.songLists);
            this.Name = "LoadList";
            this.Text = "LoadList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox songLists;
        private System.Windows.Forms.Button selectButton;
    }
}