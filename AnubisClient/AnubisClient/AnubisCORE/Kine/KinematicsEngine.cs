using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using AnubisClient.D_Hardware;
using AnubisClient.AnubisCORE.Kine;
using System.Reflection;

namespace AnubisClient
{
    /// <summary>
    /// The user interface side - This class handles interacting with the user through hardware devices.
    /// </summary>
    public static class KinematicsEngine
    {
        //Interval used to fine tune network flooding issues.
        public const int INTERVAL = 100;

        //processing thread for KinematicsEngine
        private static BackgroundWorker thread;
        //List of hardware input devices to be polled.
        private static List<HardwareInterface> readyDevices;

        private static HardwareInterface DiscoverDevices()
        {
            Type[] types = Assembly.GetAssembly(typeof(HardwareInterface)).GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Type t = types[i];
                if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(HardwareInterface)))
                {
                    HardwareInterface HI = (HardwareInterface)Activator.CreateInstance(t);
                    if (HI.detectDevice())
                    {
                        return HI;
                    }
                }
            }
            return null;
        }

        private static void StartDevices()
        {
            foreach (HardwareInterface hi in readyDevices)
            {
                hi.startDeviceServer();
            }
        }
        /// <summary>
        /// initialize - starts Kinematics Engine.
        /// </summary>
        public static void initialize()
        {
            thread = new BackgroundWorker();
            thread.WorkerSupportsCancellation = true;
            thread.DoWork += new DoWorkEventHandler(thread_doWork);
            readyDevices = new List<HardwareInterface>();

            readyDevices.Add(DiscoverDevices());
            StartDevices();
            
            thread.RunWorkerAsync();
        }

        /// <summary>
        /// thread_doWork - called by the system in a new thread.  Do not call directly.
        /// Polls hardware inputs, sends resulting skeleton to Comm engine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void thread_doWork(object sender, DoWorkEventArgs e)
        {

            while (!thread.CancellationPending)
            {
                Thread.Sleep(INTERVAL);

                // generate new skel
                SkeletonRep mod = new SkeletonRep();
                for (int i = 0; i < readyDevices.Count; i++)
                {
                    readyDevices[i].modifyModel(mod);
                }

                CommunicationsEngine.publishNewSkeleton(mod);

            }
        }
    }
}
