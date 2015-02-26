using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using AnubisClient.AnubisCORE.GUI;

namespace AnubisClient
{
    
    public partial class ClientForm : Form
    {
        private List<Form> ActiveForms;
        private StreamViewer SV;
        public ClientForm()
        {
            this.IsMdiContainer = true;
            ActiveForms = ANUBISEngine.GetActiveForms();
            SV = new StreamViewer();
            SV.MdiParent = this;

            InitializeComponent();
            
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            tscb_HardwareList.Items.Add("");
            List<string> Dev = ANUBISEngine.GetHardwareNames();
            foreach (string s in Dev)
            {
                tscb_HardwareList.Items.Add(s);
            }

            

        }

        private void tscb_HardwareList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IDENT = sender.ToString().Split(',').First().ToLower();
            foreach (Form f in ActiveForms)
            {
                if (f.Name.ToLower() == IDENT)
                {
                    f.Show();
                    
                }
            }
            ts_ViewWindow.HideDropDown();

        }

        private void ts_ViewWindow_DropDownClosed(object sender, EventArgs e)
        {
            tscb_HardwareList.SelectedIndex = 0;

        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void streamViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SV.Show();
        }

    }
}
