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

        public ProjectSong(Song newCurrentSong)
        {
            currentSong = newCurrentSong;
            GenerateParagraphs();
            InitializeComponent();
        }

        //Gets the song object from the main program to display it

        public void GenerateParagraphs()
        {
            
        }


    }
}
