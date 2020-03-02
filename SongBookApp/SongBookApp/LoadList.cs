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
    public partial class LoadList : Form
    {
        private Songlist[] listArray;

        public LoadList(Songlist[] newListArray)
        {
            listArray = newListArray;
            InitializeComponent();

            for (var i = 0; i < listArray.Length; i++)
            {
                songLists.Items.Add(listArray[i]);
            }
            
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            // Load the list into projector
        }
    }
}
