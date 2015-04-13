using AnubisClient.AnubisCORE.Kine;
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
    public partial class Kinect_Form : Form
    {
        /// <summary>
        /// A form to display data from the Kinect Manager
        /// Status: Incomplete
        /// </summary>
        private KinectManager P_Interface;
        public Kinect_Form(KinectManager Interface)
        {
            InitializeComponent();
            Name = "kinectmanager";
            P_Interface = Interface;
        }



        private void Kinect_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
