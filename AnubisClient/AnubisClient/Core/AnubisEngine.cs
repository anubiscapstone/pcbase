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
    /// Module that represents the entire system.
    /// This is the "entry point" for all of the other modules.
    /// Initializing this module will start the system up.
    /// </summary>
    static class ANUBISEngine
    {
        private static ClientForm MainHubForm = new ClientForm();
        private static SplashScreen Splash = new SplashScreen();

        //Delay in milliseconds between each frame
        public const int INTERVAL = 100;
        //main worker thread
        private static BackgroundWorker thread = new BackgroundWorker();

        private static NetworkEngine netServer = new NetworkEngine(1337);
        private static NamedPipeEngine pipeServer = new NamedPipeEngine("anubis-pipe");

        /// <summary>
        /// Called by Program.cs
        /// Starts the ANUBISENGINE.  Nothing happens before this is called. 
        /// Sets up the main form and starts up all of the other modules.
        /// </summary>
        public static void Run()
        {
            //Splash screen is displayed while we set up
            Splash.Show();
            Splash.Refresh();

            //Setup main worker thread
            thread.WorkerSupportsCancellation = true;
            thread.DoWork += new DoWorkEventHandler(thread_doWork);

            //Set up two Communication Engines.
            netServer.NewControlEvent += ControlEngine.AddNewRobot;
            netServer.StartServer();
            
            pipeServer.NewControlEvent += ControlEngine.AddNewRobot;
            pipeServer.StartServer();

            //When we're done, wait a moment and then show the main form
            Thread.Sleep(1000);
            Splash.Close();
            MainHubForm.Show();

            //Start main processing loop
            thread.RunWorkerAsync();
        }

        /// <summary>
        /// Main Processing Loop
        /// Every INTERVAL milliseconds, the Sensors are polled for a new Skeleton, Gesture recognition is ran, and the results of both are sent to the Controls
        /// </summary>
        private static void thread_doWork(object sender, DoWorkEventArgs e)
        {
            while (!thread.CancellationPending)
            {
                //Delay between frames
                Thread.Sleep(INTERVAL);

                //Poll the Sensors for a new Skeleton
                SkeletonRep mod = SensorEngine.GetNewSkeleton();

                //Run the Gesture Engine and add any recognized gestures to the Skeleton
                GestureEngine.NewFrame(mod);

                //Present the new Skeleton to the Controls
                ControlEngine.PublishNewSkeleton(mod);
            }
        }
    }
}
