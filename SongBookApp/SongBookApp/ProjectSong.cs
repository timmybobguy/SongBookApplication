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
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer,true);
            currentSong = newCurrentSong;
            InitializeComponent();
            textLabel.BackColor = Color.Transparent;
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
                Cursor.Show();
                Close();
            }
            else if (e.KeyChar == ' ' || e.KeyChar == 39)
            {
                if (currentParagraph+1 == songParagraphs.Length) // This loops back to the first paragraph, may need to be changed. Could be to close the presentation once space is clicked again.
                {
                    Cursor.Show();
                    Close();
                    //currentParagraph = 1;
                    //textLabel.Text = songParagraphs[0];
                }
                else
                {
                    currentParagraph++;
                    textLabel.Text = songParagraphs[currentParagraph];
                }
                
            }
        }
    }
}
