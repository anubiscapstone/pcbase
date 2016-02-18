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

namespace AnubisClient
{
    /// <summary>
    /// This is the main form for the application. The form is an MDI form to allow for multiple children
    /// forms within a given area of the screen
    /// </summary>
    public partial class ClientForm : Form
    {
        /// <summary>
        /// Initializes the active forms and sets the MDI Parent form
        /// </summary>
        private StreamViewer SV;
        public ClientForm()
        {
            this.IsMdiContainer = true;
            SV = new StreamViewer();
            SV.MdiParent = this;

            InitializeComponent();
            
        }

        //On Load, adds the active hardware to the toolstrip menu to allow a user to select that hardware menu
        private void ClientForm_Load(object sender, EventArgs e)
        {
            tscb_HardwareList.Items.Add("");
        }

        /// <summary>
        /// Detects a change in the hardware toolstrip selection. Opens the appropriate form for the selected hardware
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscb_HardwareList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IDENT = sender.ToString().Split(',').First().ToLower();
            ts_ViewWindow.HideDropDown();

        }

        /// <summary>
        /// Resets certain properties of the toolstrip menu when closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_ViewWindow_DropDownClosed(object sender, EventArgs e)
        {
            tscb_HardwareList.SelectedIndex = 0;

        }

        /// <summary>
        /// Closes Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Opens the stream viewing form when selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void streamViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SV.Show();
        }

    }
}
