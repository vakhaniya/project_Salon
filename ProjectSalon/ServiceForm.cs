﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProjectSalon
{
    public partial class ServiceForm : Form
    {
        Controller mainController;
        bool edit;
        Service inputService;

        public ServiceForm(Controller controller, bool edit, Service service)
        {
            InitializeComponent();
            mainController = controller;
            textBoxServiceDuration.Visible = false;
            this.edit = edit;
            inputService = service;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxServicePrice.Text.Length < 1)
                {
                    MessageBox.Show("Необходимо ввести стоимость услуги", "Ошибка", MessageBoxButtons.OK);
                    return;
                }
                if (edit)
                {
                    String name = textBoxServiceName.Text;
                    int price = Convert.ToInt32(textBoxServicePrice.Text);
                    //int duration = Convert.ToInt32(textBoxServiceDuration.Text);
                    int duration = trackBarDuration.Value;
                    mainController.changeService(name, price, duration, inputService);
                    this.Close();
                }
                else
                {
                    String name = textBoxServiceName.Text;
                    int price = Convert.ToInt32(textBoxServicePrice.Text);
                    int duration = trackBarDuration.Value;
                    mainController.registerService(name, price, duration);
                    this.Close();
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Faild to convert string to Int32: " + ex.Message);
                textBoxServicePrice.Text = "";
                MessageBox.Show("Введено слишком большое число в поле Стоимость.", "Ошибка", MessageBoxButtons.OK);
            }
            
            
        }

        private void trackBarDuration_Scroll(object sender, EventArgs e)
        {
            labelDuration.Text = Convert.ToString(trackBarDuration.Value);
        }

        private void textBoxServicePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
