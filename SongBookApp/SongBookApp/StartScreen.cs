﻿using System;
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
        public StartScreen()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("quit command recieved");
            Application.Exit();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            testTextBox.Text = "hi";
        }
    }
}