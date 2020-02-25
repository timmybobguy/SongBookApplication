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
    public partial class StartScreen : Form
    {
        private SongBook songBook;
        private FileFunctions fileFunctions;

        public StartScreen(SongBook newSongBook, FileFunctions newFileFunctions)
        {
            InitializeComponent();
            songBook = newSongBook;
            fileFunctions = newFileFunctions;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("quit command recieved");
            Application.Exit();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {

            //This is just for testing
            //string[] titles = songBook.GetAllTitles();

            //for (var i = 0; i < fileFunctions.songCount; i++)
            //{
            //    listBoxTesting.Items.Add(titles[i]);
            //}

             
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            listBoxTesting.BeginUpdate();
            listBoxTesting.Items.Clear();
            
            string[] results = songBook.GetSearchedTitles(searchBox.Text);
            for (var i = 0; i < results.Length; i++)
            {
                listBoxTesting.Items.Add(results[i]);
            }

            listBoxTesting.EndUpdate();
        }
    }
}
