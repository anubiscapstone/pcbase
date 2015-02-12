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
        public Oculus_Form()
        {
            InitializeComponent();
            this.Name = "oculus";
        }

        private void Oculus_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
}
