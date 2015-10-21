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
    public partial class Kinect_Form : Form
    {
        /// <summary>
        /// A form to display data from the Kinect Manager
        /// Status: Incomplete
        /// </summary>
        private KinectInterface P_Interface;
        public Kinect_Form(KinectInterface Interface)
        {
            InitializeComponent();
            Name = "kinectinterface";
            P_Interface = Interface;
        }



        private void Kinect_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
