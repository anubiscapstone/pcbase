using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using AnubisClient.D_Hardware;

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

        /// <summary>
        /// initialize - starts Kinematics Engine.
        /// </summary>
        public static void initialize()
        {
            thread = new BackgroundWorker();
            thread.WorkerSupportsCancellation = true;
            thread.DoWork += new DoWorkEventHandler(thread_doWork);
            readyDevices = new List<HardwareInterface>();

            //Start the Oculus Rift.
            Oculus oc = new Oculus();
            oc.startDeviceServer();
            oc.OpenVRPlayer();
            oc.detectDevice();
            
            readyDevices.Add(oc);

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
