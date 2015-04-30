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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a=textBox1.Text;
            string b=textBox2.Text;

            if (a == "admin" && b == "admin22" || a == "ADMIN" && b == "ADMIN22")
            {
                FrmPrincipal mainform = new FrmPrincipal();
                mainform.Show();
                this.Hide();
            }
            else
            {
            MessageBox.Show("Please Enter the Valid User Name & Password");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        

        
    }
}
