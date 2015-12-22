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
    public partial class ClientForm : Form
    {
        Controller mainController;

        public ClientForm(Controller controller)
        {
            InitializeComponent();
            mainController = controller;
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            String name = textBoxClientName.Text;
            String birth = textBoxClientBirth.Text;
            String number = textBoxClientNumber.Text;
            mainController.registerClient(name, birth, number);
            this.Close();
        }
    }
}
