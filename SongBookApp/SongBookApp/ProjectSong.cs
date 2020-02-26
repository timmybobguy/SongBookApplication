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
    public partial class ProjectSong : Form
    {
        private Song currentSong;
        private string[] songParagraphs;
        private int currentParagraph;

        public ProjectSong(Song newCurrentSong)
        {
            currentSong = newCurrentSong;
            InitializeComponent();
            GenerateParagraphs();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        //Gets the song object from the main program to display it

        public void GenerateParagraphs()
        {
            songParagraphs = currentSong.GetSongBody();
            //Set first paragraph to display 
            textLabel.Text = songParagraphs[0];


        }

        private void ProjectSong_KeyPress(object sender, KeyPressEventArgs e) // Keypress handler
        {
            if (e.KeyChar == 27)
            {
                Close();
            }
            else if (e.KeyChar == ' ')
            {
                currentParagraph++;
                textLabel.Text = songParagraphs[currentParagraph];
            }
        }
    }
}
