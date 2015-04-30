using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _1st first = new _1st();
            first.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
