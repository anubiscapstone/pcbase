using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AnubisClient
{
    
    public partial class ClientForm : Form
    {

        public List<HardwareInterface> Hardware;
        public List<Form> ActiveForms;
        public ClientForm()
        {
            this.IsMdiContainer = true;

            InitializeComponent();
            
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Hardware = AnubisClient.ANUBISEngine.GetActiveHardware();
            foreach (HardwareInterface hi in Hardware)
            {
                tscb_HardwareList.Items.Add(hi.getIdentString());
                
            }
        }

        private void tscb_HardwareList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(sender.ToString().Split(',').First())
            {
                
            }

        }

        private void ts_ViewWindow_DropDownClosed(object sender, EventArgs e)
        {

        }
        
    }
}
