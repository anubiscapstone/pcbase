
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
    public partial class StreamViewer : Form
    {

        public StreamViewer()
        {
            
            InitializeComponent();
           

            

        }

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
