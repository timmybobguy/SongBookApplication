using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongBookApp
{
    public partial class AddSong : Form
    {
        SongBook songBook;
        Song songBeingEdited;
        FileFunctions fileFunctions;
        bool isNewSong;

        public AddSong(bool isNew, Song existingSong, SongBook newSongBook, FileFunctions newFileFunctions)
        {
            InitializeComponent();
            fileFunctions = newFileFunctions;
            isNewSong = isNew;
            songBook = newSongBook;

            if (!isNew)
            {
                songBeingEdited = existingSong;
                textBoxTitle.Text = existingSong.title;
                songBody.Text = existingSong.body;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text != "" && songBody.Text != "")
            {
                if (isNewSong) // If a new song is being added
                {
                    int num = songBook.songCount;
                    songBook.AddSong(num - 1, num - 1, 0, num, textBoxTitle.Text, "", songBody.Text);
                    songBook.songCount++;
                    fileFunctions.ToXML();
                    Close();
                }
                else // IF a song is being edited
                {
                    songBeingEdited.body = songBody.Text;
                    songBeingEdited.title = textBoxTitle.Text;
                    fileFunctions.ToXML();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a title and song body", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}
