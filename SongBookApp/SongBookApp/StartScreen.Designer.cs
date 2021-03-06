﻿namespace SongBookApp
{
    partial class StartScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSongDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSongListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSongListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxTesting = new System.Windows.Forms.ListBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.testProject = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.songBody = new System.Windows.Forms.RichTextBox();
            this.checkBoxSearch = new System.Windows.Forms.CheckBox();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.checkBoxInSong = new System.Windows.Forms.CheckBox();
            this.importexportSongListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.songListToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSongToolStripMenuItem,
            this.importSongDatabaseToolStripMenuItem,
            this.importexportSongListsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newSongToolStripMenuItem
            // 
            this.newSongToolStripMenuItem.Name = "newSongToolStripMenuItem";
            this.newSongToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.newSongToolStripMenuItem.Text = "Create new song";
            this.newSongToolStripMenuItem.Click += new System.EventHandler(this.newSongToolStripMenuItem_Click);
            // 
            // importSongDatabaseToolStripMenuItem
            // 
            this.importSongDatabaseToolStripMenuItem.Name = "importSongDatabaseToolStripMenuItem";
            this.importSongDatabaseToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.importSongDatabaseToolStripMenuItem.Text = "Import/export songs";
            this.importSongDatabaseToolStripMenuItem.Click += new System.EventHandler(this.importSongDatabaseToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // songListToolStripMenuItem
            // 
            this.songListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewListToolStripMenuItem,
            this.loadSongListToolStripMenuItem,
            this.editSongListToolStripMenuItem});
            this.songListToolStripMenuItem.Name = "songListToolStripMenuItem";
            this.songListToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.songListToolStripMenuItem.Text = "Song list";
            // 
            // createNewListToolStripMenuItem
            // 
            this.createNewListToolStripMenuItem.Name = "createNewListToolStripMenuItem";
            this.createNewListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.createNewListToolStripMenuItem.Text = "Create new list";
            this.createNewListToolStripMenuItem.Click += new System.EventHandler(this.createNewListToolStripMenuItem_Click);
            // 
            // loadSongListToolStripMenuItem
            // 
            this.loadSongListToolStripMenuItem.Name = "loadSongListToolStripMenuItem";
            this.loadSongListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.loadSongListToolStripMenuItem.Text = "Load song list";
            this.loadSongListToolStripMenuItem.Click += new System.EventHandler(this.loadSongListToolStripMenuItem_Click);
            // 
            // editSongListToolStripMenuItem
            // 
            this.editSongListToolStripMenuItem.Name = "editSongListToolStripMenuItem";
            this.editSongListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.editSongListToolStripMenuItem.Text = "Edit song list";
            this.editSongListToolStripMenuItem.Click += new System.EventHandler(this.editSongListToolStripMenuItem_Click);
            // 
            // listBoxTesting
            // 
            this.listBoxTesting.FormattingEnabled = true;
            this.listBoxTesting.Location = new System.Drawing.Point(12, 103);
            this.listBoxTesting.Name = "listBoxTesting";
            this.listBoxTesting.Size = new System.Drawing.Size(237, 290);
            this.listBoxTesting.TabIndex = 2;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 45);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(237, 20);
            this.searchBox.TabIndex = 3;
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_KeyPress);
            // 
            // testProject
            // 
            this.testProject.Location = new System.Drawing.Point(12, 399);
            this.testProject.Name = "testProject";
            this.testProject.Size = new System.Drawing.Size(237, 23);
            this.testProject.TabIndex = 5;
            this.testProject.Text = "Project song";
            this.testProject.UseVisualStyleBackColor = true;
            this.testProject.Click += new System.EventHandler(this.testProject_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(317, 45);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(16, 13);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "   ";
            // 
            // songBody
            // 
            this.songBody.Location = new System.Drawing.Point(319, 103);
            this.songBody.Margin = new System.Windows.Forms.Padding(0);
            this.songBody.Name = "songBody";
            this.songBody.Size = new System.Drawing.Size(233, 290);
            this.songBody.TabIndex = 7;
            this.songBody.Text = "";
            // 
            // checkBoxSearch
            // 
            this.checkBoxSearch.AutoSize = true;
            this.checkBoxSearch.Location = new System.Drawing.Point(12, 80);
            this.checkBoxSearch.Name = "checkBoxSearch";
            this.checkBoxSearch.Size = new System.Drawing.Size(127, 17);
            this.checkBoxSearch.TabIndex = 8;
            this.checkBoxSearch.Text = "Search alphabetically";
            this.checkBoxSearch.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(319, 399);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(113, 23);
            this.editButton.TabIndex = 10;
            this.editButton.Text = "Edit song";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(439, 399);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(113, 23);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Delete song";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // checkBoxInSong
            // 
            this.checkBoxInSong.AutoSize = true;
            this.checkBoxInSong.Location = new System.Drawing.Point(152, 80);
            this.checkBoxInSong.Name = "checkBoxInSong";
            this.checkBoxInSong.Size = new System.Drawing.Size(97, 17);
            this.checkBoxInSong.TabIndex = 12;
            this.checkBoxInSong.Text = "Search in song";
            this.checkBoxInSong.UseVisualStyleBackColor = true;
            // 
            // importexportSongListsToolStripMenuItem
            // 
            this.importexportSongListsToolStripMenuItem.Name = "importexportSongListsToolStripMenuItem";
            this.importexportSongListsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.importexportSongListsToolStripMenuItem.Text = "Import/export song lists";
            this.importexportSongListsToolStripMenuItem.Click += new System.EventHandler(this.importexportSongListsToolStripMenuItem_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 431);
            this.Controls.Add(this.songBody);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.listBoxTesting);
            this.Controls.Add(this.checkBoxInSong);
            this.Controls.Add(this.testProject);
            this.Controls.Add(this.checkBoxSearch);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 460);
            this.Name = "StartScreen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SongBook";
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxTesting;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button testProject;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.RichTextBox songBody;
        private System.Windows.Forms.CheckBox checkBoxSearch;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ToolStripMenuItem newSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSongDatabaseToolStripMenuItem;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox checkBoxInSong;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSongListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSongListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importexportSongListsToolStripMenuItem;
    }
}