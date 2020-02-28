using SongBookApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongBookApp
{
    public partial class SettingsMenu : Form
    {
        private SongBook theSongBook;

        public SettingsMenu(SongBook songbook)
        {
            theSongBook = songbook;
            InitializeComponent();
            trackBarValue.Value = theSongBook.fontSize;
            sliderValueLabel.Text = trackBarValue.Value.ToString();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            sliderValueLabel.Text = trackBarValue.Value.ToString();
            theSongBook.fontSize = trackBarValue.Value;

            //THIS COULD BE CHANGED

            //Settings.Default.SettingsKey.
            //Settings.Default. = MyNewValue;
            //Settings.Default.Save();
            //ConfigurationManager.AppSettings.Remove("fontSize");
            //ConfigurationManager.AppSettings.Add("fontSize", trackBarValue.Value.ToString());
            //ConfigurationManager.AppSettings.Set("fontSize", trackBarValue.Value.ToString());
        }
    }
}
