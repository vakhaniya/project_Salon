﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSalon
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newRecordToolboxButton_Click(object sender, EventArgs e)
        {
            Form newRecordForm = new RecordForm();
            newRecordForm.ShowDialog(this);
        }

        private void newClientToolboxButton_Click(object sender, EventArgs e)
        {
            Form newClientForm = new ClientForm();
            newClientForm.ShowDialog(this);
        }
    }
}
