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
        Song songBeingEdited;
        bool isNewSong;

        public AddSong(bool isNew, Song existingSong)
        {
            InitializeComponent();
            isNewSong = isNew;

            if (!isNew)
            {
                songBeingEdited = existingSong;
                textBoxTitle.Text = existingSong.title;
                songBody.Text = existingSong.body;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isNewSong) // If a new song is being added
            {

            }
            else // IF a song is being edited
            {
                songBeingEdited.body = songBody.Text;
                songBeingEdited.title = textBoxTitle.Text;
                Close();
            }
            
        }
    }
}
