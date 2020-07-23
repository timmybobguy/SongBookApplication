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
        private int fontSize;

        public ProjectSong(Song newCurrentSong, int newFontSize)
        {
            fontSize = newFontSize;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer,true);
            currentSong = newCurrentSong;
            InitializeComponent();
            textLabel.BackColor = Color.Transparent;
            textLabel.Font = new Font("Arial", fontSize);
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

        public void setText()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            textLabel.AutoSize = true;
            textLabel.TextAlign = ContentAlignment.MiddleLeft;
            textLabel.Dock = DockStyle.None;
            textLabel.Location = new Point((screenWidth / 2) - (textLabel.Size.Width / 2), (screenHeight / 2) - (textLabel.Size.Height / 2));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                if (currentParagraph != 0)
                {
                    currentParagraph = currentParagraph - 1;
                    textLabel.Text = songParagraphs[currentParagraph];
                }
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                if (currentParagraph + 1 != songParagraphs.Length)
                {
                    currentParagraph++;
                    textLabel.Text = songParagraphs[currentParagraph];
                }
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                if(currentParagraph != 0)
                {
                    currentParagraph = currentParagraph - 1;
                    textLabel.Text = songParagraphs[currentParagraph];
                }
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                if(currentParagraph + 1 != songParagraphs.Length)
                {
                    currentParagraph++;
                    textLabel.Text = songParagraphs[currentParagraph];
                }
                return true;
            }
            //capture pagedown
            if (keyData == Keys.PageDown)
            {
                if (currentParagraph + 1 != songParagraphs.Length)
                {
                    currentParagraph++;
                    textLabel.Text = songParagraphs[currentParagraph];
                }
                return true;
            }
            //capture pageup
            if (keyData == Keys.PageUp)
            {
                if (currentParagraph != 0)
                {
                    currentParagraph = currentParagraph - 1;
                    textLabel.Text = songParagraphs[currentParagraph];
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ProjectSong_KeyPress(object sender, KeyPressEventArgs e) // Keypress handler
        {
            if (e.KeyChar == 27)
            {
                Cursor.Show();
                Close();
            }
            else if (e.KeyChar == ' ')
            {
                if (currentParagraph + 1 != songParagraphs.Length)
                {
                    currentParagraph++;
                    textLabel.Text = songParagraphs[currentParagraph];
                }    
            }
        }
    }
}
