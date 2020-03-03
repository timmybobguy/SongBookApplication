using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool editingSongList;
        private Songlist listToEdit;

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
            try
            {
                string x = Path.Combine(fileFunctions.savePath, "..\\");
                Process.Start(@x);
            }
            catch (Win32Exception win32Exception)
            {
                //The system cannot find the file specified...
                Console.WriteLine(win32Exception.Message);
            }
            //OpenFileDialog openFileDialog1 = new OpenFileDialog
            //{
            //    Title = "Select song database",
            //    Filter = "XML files (*.xml)|*.xml"
            //};


            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //textBox1.Text = openFileDialog1.FileName;
            //}
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
            Songlist[] x = new Songlist[fileFunctions.songListManger.allMySongLists.Count];
            for (var i = 0; i < fileFunctions.songListManger.allMySongLists.Count; i++)
            {
                x[i] = fileFunctions.songListManger.allMySongLists[i];
            }

            LoadList test = new LoadList(x, songBook, true);

            test.ShowDialog();

        }

        private void createNewListToolStripMenuItem_Click(object sender, EventArgs e) // CREATING NEW SONG LIST
        {
            
        }

        private void editSongListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editingSongList = true;
            Songlist[] x = new Songlist[fileFunctions.songListManger.allMySongLists.Count];
            for (var i = 0; i < fileFunctions.songListManger.allMySongLists.Count; i++)
            {
                x[i] = fileFunctions.songListManger.allMySongLists[i];
            }

            LoadList test = new LoadList(x, songBook, false);

            DialogResult loadPicker = test.ShowDialog();

            if (loadPicker == DialogResult.OK)
            {
                listToEdit = test.listToEdit;

                //Now hide/disable all controls that shouldnt be able to be interacted with

                listLayout();

                // Now display the songList

                Control[] selected = Controls.Find("songListBox", true);
                ListBox listbox = (ListBox)selected[0];
                Control[] titleSelected = Controls.Find("songTitle", true);
                TextBox titleTextBox = (TextBox)titleSelected[0];

                for (var y = 0; y < listToEdit.songListArray.Length; y++)
                {
                    int songListNum = listToEdit.songListArray[y];
                    listbox.Items.Add(songBook.allMySongs[songListNum]);
                }

                titleTextBox.Text = listToEdit.listName;

            }


        }

        private void listLayout()
        {
            deleteButton.Visible = false;
            editButton.Visible = false;
            testProject.Visible = false;
            fileToolStripMenuItem.Enabled = false;
            songListToolStripMenuItem.Enabled = false;

            songBody.Location = new Point(275, 103);

            Size =  new Size( 900, 470 );

            Button saveList = new Button
            {
                Name = "saveListButton",
                Location = new Point(525, 370),
                Text = "Save list",
                Height = 25,
                Width = 100,
                BackColor = Color.White
            };

            saveList.Click += new EventHandler(btn_Click);

            Controls.Add(saveList);

            Button add = new Button
            {
                Name = "add",
                Location = new Point(525, 150),
                Text = "Add song",
                Height = 25,
                Width = 100,
                BackColor = Color.White
            };

            add.Click += new EventHandler(btn_Click);

            Controls.Add(add);

            Button remove = new Button
            {
                Name = "remove",
                Location = new Point(525, 175),
                Text = "Remove song",
                Height = 25,
                Width = 100,
                BackColor = Color.White
            };

            remove.Click += new EventHandler(btn_Click);

            Controls.Add(remove);

            ListBox songListBox = new ListBox
            {
                Name = "songListBox",
                Location = new Point(635, 103),
                Height = 290,
                Width = 237
            };

            Controls.Add(songListBox);

            TextBox songTitle = new TextBox
            {
                Name = "songTitle",
                Location = new Point(700, 45),
                Height = 20,
                Width = 150

            };

            Controls.Add(songTitle);

            Label label = new Label
            {
                Location = new Point(640, 47),
                Text = "List name:",
                Height = 20,
                Width = 100
            };

            Controls.Add(label);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button x = sender as Button;

            Control[] selected = Controls.Find("songListBox", true);
            ListBox listbox = (ListBox)selected[0];

            Control[] titleSelected = Controls.Find("songTitle", true);
            TextBox titleTextBox = (TextBox)titleSelected[0];

            switch (x.Name)
            {
                case "saveListButton":
                    //Add song list to model and save to file

                    if (listbox.Items.Count == 0 || titleTextBox.Text == "")
                    {
                        MessageBox.Show("Please have at least one song in your list and have a name", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (editingSongList)
                        {
                            int[] songListString = new int[listbox.Items.Count];
                            int count = 0;
                            foreach (var item in listbox.Items)
                            {
                                Song currSong = (Song)item;
                                songListString[count] += currSong.id;
                                count++;
                            }

                            listToEdit.songListArray = songListString;
                            listToEdit.listName = titleTextBox.Text;

                            //songBook.songListManager.allMySongLists[x].songListString = songListString etc... 
                        }
                        else
                        {
                            int[] songListString = new int[listbox.Items.Count];
                            int count = 0;
                            foreach (var item in listbox.Items)
                            {
                                Song currSong = (Song)item;
                                songListString[count] += currSong.songNum;
                                count++;
                            }

                            songBook.songListManager.AddSongList(songListString, titleTextBox.Text);

                        }

                        fileFunctions.ListsToXML();
                        editingSongList = false;

                        //Reset form back to original state
                        Controls.Clear();
                        InitializeComponent();
                    }

                    break;
                case "add":

                    if (listBoxTesting.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select a song before trying to add it to the list", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        listbox.Items.Add(listBoxTesting.SelectedItem);
                    }

                    break;
                case "remove":
                    Console.WriteLine("Case 1");
                    break;
            }

        }
    }
}
