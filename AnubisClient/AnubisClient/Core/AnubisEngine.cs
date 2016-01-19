using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AnubisClient
{
    /// <summary>
    /// Encapsulates all robot interaction functionality.  The only things outside of this class are the 
    /// standard Windows user interface.
    /// </summary>
    static class ANUBISEngine
    {
        private static List<SensorInterface> ActiveHardware;
        private static List<Form> ActiveForms;
        private static ClientForm MainHubForm;
        private static System.Windows.Forms.Timer SplashTimer;
        private static SplashScreen Splash;
        /// <summary>
        /// Initialize starts the ANUBISENGINE.  Nothing happens before this is called. 
        /// Starts the Communications Engine and Kinematics Engine.
        /// </summary>
        public static void Initialize() //Already being called by Program.cs
        {
            ActiveForms = new List<Form>();
            SplashTimer = new System.Windows.Forms.Timer();
            Splash = new SplashScreen();
            Splash.Show();
            Splash.Refresh();
            SplashTimer.Interval = 2000;
            SplashTimer.Tick += SplashTimer_Tick;
            SplashTimer.Start();

            ControlEngine.initialize();
            SensorEngine.initialize();

            ActiveHardware = SensorEngine.GetActiveDevices();

            NetworkEngine netServer = new NetworkEngine(1337);
            netServer.newRobotEvent += ControlEngine.addNewRobot;
            netServer.startServer();

            NamedPipeEngine pipeServer = new NamedPipeEngine("anubis-pipe");
            pipeServer.newRobotEvent += ControlEngine.addNewRobot;
            pipeServer.startServer();
            
            MainHubForm = new ClientForm();

            foreach (SensorInterface hi in ActiveHardware)
            {
                Form Temp = hi.getForm();
                Temp.MdiParent = MainHubForm;
                ActiveForms.Add(Temp);

            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void SplashTimer_Tick(object sender, EventArgs e)
        {
            Splash.Close();
            Thread.Sleep(500);
            MainHubForm.Show();
        }

        public static List<Form> GetActiveForms()
        {
            return ActiveForms;
        }

        public static List<string> GetHardwareNames()
        {
            List<string> ret = new List<string>();
            foreach (SensorInterface hi in ActiveHardware)
            {
                ret.Add(hi.getIdentString());
            }
            return ret;
        }


    }
}
