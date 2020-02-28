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
    public partial class SettingsMenu : Form
    {
        public SettingsMenu()
        {
            InitializeComponent();
            sliderValueLabel.Text = trackBarValue.Value.ToString();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            sliderValueLabel.Text = trackBarValue.Value.ToString();
        }
    }
}
