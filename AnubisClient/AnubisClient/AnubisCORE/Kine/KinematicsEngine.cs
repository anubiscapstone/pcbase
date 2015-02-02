using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using AnubisClient.D_Hardware;

namespace AnubisClient
{
    
    public static class KinematicsEngine
    {
        public const int INTERVAL = 100;

        private static BackgroundWorker thread;
        private static List<HardwareInterface> readyDevices;

        public static void initialize()
        {
            thread = new BackgroundWorker();
            thread.WorkerSupportsCancellation = true;
            thread.DoWork += new DoWorkEventHandler(thread_doWork);
            readyDevices = new List<HardwareInterface>();

            Oculus oc = new Oculus();
            oc.startDeviceServer();
            oc.detectDevice();
            
            readyDevices.Add(oc);

            thread.RunWorkerAsync();
        }

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
