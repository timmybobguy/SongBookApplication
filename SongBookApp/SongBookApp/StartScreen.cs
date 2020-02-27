using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void testProject_Click(object sender, EventArgs e)
        {
            Song testsong = ((Song)songBook.allMySongs[11]);

            testsong.GetSongBody();

            ProjectSong test = new ProjectSong(testsong);

            Cursor.Hide();

            test.ShowDialog();
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                listBoxTesting.BeginUpdate();
                listBoxTesting.Items.Clear();


                switch (checkBoxSearch.CheckState)
                {
                    case CheckState.Checked:
                        // Code for checked state.  

                        if (searchBox.Text.Length == 1 && Regex.IsMatch(searchBox.Text, @"^[a-zA-Z]+$"))
                        {
                            string[] resultsFirstLetter = songBook.GetSearchedTitles(searchBox.Text, true);
                            for (var i = 0; i < resultsFirstLetter.Length; i++)
                            {
                                listBoxTesting.Items.Add(resultsFirstLetter[i]);
                            }
                        }
                        else
                        {
                            MessageBox.Show("When searching alphabetically use only a single character, such as 'a' or 'A'", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }


                        break;
                    case CheckState.Unchecked:
                        // Code for unchecked state. 


                        string[] results = songBook.GetSearchedTitles(searchBox.Text, false);
                        for (var i = 0; i < results.Length; i++)
                        {
                            listBoxTesting.Items.Add(results[i]);
                        }



                        break;
                    case CheckState.Indeterminate:
                        // Code for indeterminate state. 

                        Console.WriteLine("errorHasOccured");

                        break;
                }

                listBoxTesting.EndUpdate();
            }
        }
    }
}
