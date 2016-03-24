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
                case 2:
                    refreshComms();
                    HideCommArgs();
                    break;
                default:
                    break;
            }
        }

        private List<SensorInterface> sensorList = new List<SensorInterface>();
        private List<SensorInterface> activeSensorList = new List<SensorInterface>();
        private SensorInterface selectSensor;
        private SensorInterface selectActiveSensor;

        private void refreshSensors()
        {
            activeSensorListBox.Items.Clear();
            activeSensorList = activeSensorList.Where((a) => { return a.IsTracking(); }).ToList(); //ensure still active
            foreach (SensorInterface s in activeSensorList)
                activeSensorListBox.Items.Add(s.Name());

            sensorListBox.Items.Clear();
            sensorList = SensorEngine.DiscoverDevices();
            foreach (SensorInterface s in sensorList)
                if(!activeSensorList.Exists((a) => { return a.GetType() == s.GetType(); })) sensorListBox.Items.Add(s.Name()); //only inactive
        }

        private void refreshSensorsBtn_Click(object sender, EventArgs e)
        {
            refreshSensors();
        }

        private void sensorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sensorList != null && sensorList.Count > 0)
            {
                selectSensor = sensorList[(sender as ListBox).SelectedIndex];
            }
        }

        private void startSensorBtn_Click(object sender, EventArgs e)
        {
            if(selectSensor != null)
            {
                SensorEngine.StartDevice(selectSensor);
                activeSensorList.Add(selectSensor);
                refreshSensors();
            }
        }

        private void activeSensorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activeSensorList != null && activeSensorList.Count > 0)
            {
                selectActiveSensor = activeSensorList[(sender as ListBox).SelectedIndex];
            }
        }

        private void stopSensorBtn_Click(object sender, EventArgs e)
        {
            if (selectActiveSensor != null)
            {
                SensorEngine.StopDevice(selectActiveSensor);
                activeSensorList.Remove(selectActiveSensor);
                refreshSensors();
            }
        }

        private List<CommunicationsEngine> activeCommsList = new List<CommunicationsEngine>();
        private List<Type> commsTypeList = new List<Type>();
        private Type selectComm;
        private CommunicationsEngine selectActiveComm;
        private int commArgCount = 0;
        private Type[] commArgTypes = new Type[5];

        private Tuple<Label, TextBox> getCommArgBoxes(int i)
        {
            if (i == 0)
                return new Tuple<Label, TextBox>(commArg1Lbl, commArg1Txt);
            if (i == 1)
                return new Tuple<Label, TextBox>(commArg2Lbl, commArg2Txt);
            if (i == 2)
                return new Tuple<Label, TextBox>(commArg3Lbl, commArg3Txt);
            if (i == 3)
                return new Tuple<Label, TextBox>(commArg4Lbl, commArg4Txt);
            if (i == 4)
                return new Tuple<Label, TextBox>(commArg5Lbl, commArg5Txt);
            return null;
        }

        private void refreshComms()
        {
            activeCommListBox.Items.Clear();
            foreach (CommunicationsEngine ce in activeCommsList)
                activeCommListBox.Items.Add(ce.Identifier());

            commsTypeList.Clear();
            commListBox.Items.Clear();
            foreach (Type t in Assembly.GetAssembly(typeof(CommunicationsEngine)).GetTypes())
                if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(CommunicationsEngine)))
                {
                    commsTypeList.Add(t);
                    commListBox.Items.Add(t.Name);
                }
        }

        private void HideCommArgs()
        {
            for (int i = 0; i < 5; i++)
            {
                Tuple<Label, TextBox> b = getCommArgBoxes(i);
                b.Item1.Hide();
                b.Item2.Hide();
            }
        }

        private void commListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideCommArgs();
            if (commsTypeList != null && commsTypeList.Count > 0)
            {
                selectComm = commsTypeList[(sender as ListBox).SelectedIndex];
                commArgCount = 0;
                foreach(ParameterInfo p in selectComm.GetConstructors()[0].GetParameters())
                {
                    Tuple<Label, TextBox> b = getCommArgBoxes(commArgCount);
                    if (b == null)
                    {
                        selectComm = null;
                        commArgCount = 0;
                        HideCommArgs();
                        return;
                    }
                    b.Item1.Text = p.Name;
                    b.Item1.Show();
                    b.Item2.Show();
                    commArgTypes[commArgCount++] = p.ParameterType;
                }
            }
        }

        private void startcommBtn_Click(object sender, EventArgs e)
        {
            if (selectComm != null)
            {
                if (commArgCount == 0)
                {
                    activeCommsList.Add((CommunicationsEngine)Activator.CreateInstance(selectComm));
                    return;
                }

                object[] parms = new object[commArgCount];
                for (int i = 0; i < commArgCount; i++)
                {
                    Tuple<Label, TextBox> b = getCommArgBoxes(i);
                    if (b == null)
                        return;
                    if (commArgTypes[i] == typeof(String))
                        parms[i] = b.Item2.Text;
                    else if (commArgTypes[i] == typeof(int))
                    {
                        int p;
                        if (!int.TryParse(b.Item2.Text, out p))
                            return;
                        parms[i] = p;
                    }
                }
                CommunicationsEngine ce = (CommunicationsEngine)Activator.CreateInstance(selectComm, parms);
                if (ce == null)
                    return;
                ce.NewControlEvent += ControlEngine.AddNewRobot;
                ce.StartServer();
                activeCommsList.Add(ce);
                refreshComms();
            }
        }

        private void activeCommListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activeCommsList != null && activeCommsList.Count > 0)
            {
                selectActiveComm = activeCommsList[(sender as ListBox).SelectedIndex];
            }
        }

        private void stopCommBtn_Click(object sender, EventArgs e)
        {
            if (selectActiveComm != null)
            {
                selectActiveComm.StopServer();
                activeCommsList.Remove(selectActiveComm);
            }
            refreshComms();
        }
    }
}
