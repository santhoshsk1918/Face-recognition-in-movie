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
    public partial class intermediate : Form
    {
        public intermediate()
        {
            InitializeComponent();
        }

        private void intermediate_Load(object sender, EventArgs e)
        {
            //this is emoty
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPrincipal mainform = new FrmPrincipal();
            mainform.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            onefacedetection onefacedetection = new onefacedetection();
            onefacedetection.Show();
            this.Hide();
        }

        private void intermediate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
