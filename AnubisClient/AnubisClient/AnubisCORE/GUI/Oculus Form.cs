using AnubisClient.D_Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnubisClient
{
    public partial class Oculus_Form : Form
    {
        private Oculus P_Interface;
        public Oculus_Form(Oculus Interface)
        {
            InitializeComponent();
            this.Name = "oculus";
            P_Interface = Interface;
           
        }

        private void Oculus_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Oculus_Form_Activated(object sender, EventArgs e)
        {
            P_Interface.OpenVRPlayer();
        }

        private void btn_startVrPlayer_Click(object sender, EventArgs e)
        {
            //P_Interface.OpenVRPlayer();
        }

    }
}
