using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Reflection;

namespace AnubisClient
{
    /// <summary>
    /// The user interface side - This class handles interacting with the user through hardware devices.
    /// </summary>
    public static class SensorEngine
    {
        //Interval used to fine tune network flooding issues.
        public const int INTERVAL = 100;

        //processing thread for SensorEngine
        private static BackgroundWorker thread;
        //List of hardware input devices to be polled.
        private static List<SensorInterface> readyDevices;

        private static List<SensorInterface> DiscoverDevices()
        {
            List<SensorInterface> devices = new List<SensorInterface>();
            Type[] types = Assembly.GetAssembly(typeof(SensorInterface)).GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Type t = types[i];
                if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(SensorInterface)))
                {
                    SensorInterface HI = (SensorInterface)Activator.CreateInstance(t);
                    if (HI.detectDevice())
                    {
                        devices.Add(HI);

                    }
                }
            }

            if (devices.Count == 0)
            return null;

            return devices;
        }

        private static void StartDevices()
        {
            foreach (SensorInterface hi in readyDevices)
            {
                hi.startDeviceServer();
            }
        }

        public static List<SensorInterface> GetActiveDevices()
        {
            return readyDevices;
        }
        /// <summary>
        /// initialize - starts Kinematics Engine.
        /// </summary>
        public static void initialize()
        {
            thread = new BackgroundWorker();
            thread.WorkerSupportsCancellation = true;
            thread.DoWork += new DoWorkEventHandler(thread_doWork);
            readyDevices = new List<SensorInterface>();
            readyDevices = DiscoverDevices();
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

                ControlEngine.publishNewSkeleton(mod);

            }
        }
    }
}
