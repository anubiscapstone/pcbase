
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace AnubisClient.AnubisCORE.GUI
{
    /// <summary>
    /// A small webpage form for watching the video stream from the robot
    /// </summary>
    public partial class StreamViewer : Form
    {

        public StreamViewer()
        {
            
            InitializeComponent();
           

            

        }

        /// <summary>
        /// Cancel the form close and hide instead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StreamViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void StreamViewer_SizeChanged(object sender, EventArgs e)
        {
            
        }
    }
}
