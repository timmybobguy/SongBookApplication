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
    public partial class LoadList : Form
    {
        private Songlist[] listArray;
        public SongBook songBook;
        private bool project;
        public Songlist listToEdit;

        public LoadList(Songlist[] newListArray, SongBook newSongBook, bool doProject)
        {
            project = doProject;
            songBook = newSongBook;
            listArray = newListArray;
            InitializeComponent();

            for (var i = 0; i < listArray.Length; i++)
            {
                songLists.Items.Add(listArray[i]);
            }
            
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (songLists.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a song list", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (project)
            {
                Songlist currSongList = (Songlist)songLists.SelectedItem;

                int[] songs = currSongList.songListArray;

                for (var i = 0; i < songs.Length; i++)
                {
                    Cursor.Show();
                    Song song = songBook.allMySongs[songs[i]];
                    ProjectSong project = new ProjectSong(song, songBook.fontSize);
                    MessageBox.Show(song.songNum + "# " + song.title, "Song list: " + currSongList.listName, MessageBoxButtons.OK);
                    Cursor.Hide();
                    project.ShowDialog();
                }

            } 
            else
            {
                listToEdit = (Songlist)songLists.SelectedItem;
                Close();
            }
        }
    }
}
