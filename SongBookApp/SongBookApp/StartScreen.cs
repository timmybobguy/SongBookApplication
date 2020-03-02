using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            fileFunctions.ToXML();
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
            if (listBoxTesting.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a song before trying to project", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Song testsong = (Song)listBoxTesting.SelectedItem;

                testsong.GetSongBody();

                ProjectSong test = new ProjectSong(testsong, songBook.fontSize);

                Cursor.Hide();

                test.ShowDialog();
            }
            
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                listBoxTesting.BeginUpdate();
                listBoxTesting.Items.Clear();

                titleLabel.Text = "";
                songBody.Text = "";

                switch (checkBoxSearch.CheckState)
                {
                    case CheckState.Checked:
                        // Code for checked state.  

                        if (searchBox.Text.Length == 1 && Regex.IsMatch(searchBox.Text, @"^[a-zA-Z]+$"))
                        {
                            object[] resultsFirstLetter = songBook.GetSearchedTitles(searchBox.Text, true);
                            for (var i = 0; i < resultsFirstLetter.Length; i++)
                            {
                                listBoxTesting.Items.Add((Song)resultsFirstLetter[i]);
                            }
                        }
                        else
                        {
                            MessageBox.Show("When searching by first letter of title use only a single character, such as 'a' or 'A'", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }


                        break;
                    case CheckState.Unchecked:
                        // Code for unchecked state. 

                        if (checkBoxInSong.CheckState == CheckState.Checked)
                        {
                            object[] results = songBook.SearchSongs(searchBox.Text, 3);
                            for (var i = 0; i < results.Length; i++)
                            {
                                listBoxTesting.Items.Add((Song)results[i]);
                            }
                        }
                        else
                        {
                            object[] results = songBook.GetSearchedTitles(searchBox.Text, false);
                            for (var i = 0; i < results.Length; i++)
                            {
                                listBoxTesting.Items.Add((Song)results[i]);
                            }
                        }
                        



                        break;
                    case CheckState.Indeterminate:
                        // Code for indeterminate state. 

                        Console.WriteLine("errorHasOccured");

                        break;
                }

                listBoxTesting.SelectedValueChanged += new EventHandler(ListboxTesting_SelectedValueChanged);

                listBoxTesting.EndUpdate();
            }
        }

        private void ListboxTesting_SelectedValueChanged(object sender, EventArgs e) // Trigger for when a song is selected 
        {
            
            ListBox listbox = (ListBox)sender;

            if (listbox.SelectedItem != null)
            {
                Song selected = (Song)listbox.SelectedItem;

                titleLabel.Text = selected.title + " #" + selected.songNum;
                songBody.Text = selected.body;
            }
            //MessageBox.Show(listbox.SelectedItem.ToString());

            //Displaying the selected song

            
        }

        private void importSongDatabaseToolStripMenuItem_Click(object sender, EventArgs e) // This will replace the song database with a new one and then close the application
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Select song database",
                Filter = "XML files (*.xml)|*.xml"
            };


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //textBox1.Text = openFileDialog1.FileName;

                
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {

            if (listBoxTesting.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a song before trying to edit", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                AddSong test = new AddSong(false, (Song)listBoxTesting.SelectedItem, songBook, fileFunctions);
                test.ShowDialog();
                titleLabel.Text = "";
                songBody.Text = "";
            }
        }

        private void newSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSong test = new AddSong(true, null, songBook, fileFunctions);
            test.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBoxTesting.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a song before trying to delete it", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                songBook.allMySongs.Remove((Song)listBoxTesting.SelectedItem);
                fileFunctions.ToXML();
                listBoxTesting.Items.Clear();
                titleLabel.Text = "";
                songBody.Text = "";
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) //Settings menu
        {
            SettingsMenu test = new SettingsMenu(songBook);

            test.ShowDialog();
        }

        private void loadSongListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(songBook.fileFunctions.filePath, "..\\..\\songLists");
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Select song list",
                Filter = "XML files (*.xml)|*.xml",
                InitialDirectory = path
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //textBox1.Text = openFileDialog1.FileName;


            }

        }
    }
}