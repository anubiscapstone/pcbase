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
        public ClientForm()
        {
            InitializeComponent();
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

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int i = (sender as TabControl).SelectedIndex;
            switch (i)
            {
                case 1:
                    refreshSensors();
                    break;
                default:
                    break;
            }
        }

        private void refreshSensors()
        {
            sensorListBox.Items.Clear();
            sensorList = SensorEngine.DiscoverDevices();
            foreach (SensorInterface s in sensorList)
            {
                sensorListBox.Items.Add(s.Name());
            }
        }

        private void refreshSensorsBtn_Click(object sender, EventArgs e)
        {
            refreshSensors();
        }

        private List<SensorInterface> sensorList;
        private SensorInterface selectSensor;

        private void sensorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sensorList != null)
            {
                selectSensor = sensorList[(sender as ListBox).SelectedIndex];
            }
        }

        private void startSensorBtn_Click(object sender, EventArgs e)
        {
            if(selectSensor != null)
            {
                SensorEngine.StartDevice(selectSensor);
            }
        }
    }
}
