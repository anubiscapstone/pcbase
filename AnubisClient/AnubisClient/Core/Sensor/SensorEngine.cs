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
        //List of sensor devices to be polled.
        private static List<SensorInterface> readyDevices;

        /// <summary>
        /// Finds all of the Sensors that can be started and starts them.
        /// This should be called to have the system start "sensing"
        /// </summary>
        public static void StartDevices()
        {
            DiscoverDevices();
            foreach (SensorInterface hi in readyDevices)
                hi.StartDeviceServer();
        }

        /// <summary>
        /// Finds all of the devices that can be started
        /// </summary>
        private static void DiscoverDevices()
        {
            List<SensorInterface> devices = new List<SensorInterface>();
            Type[] types = Assembly.GetAssembly(typeof(SensorInterface)).GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Type t = types[i];
                if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(SensorInterface)))
                {
                    SensorInterface HI = (SensorInterface)Activator.CreateInstance(t);
                    if (HI.DetectDevice())
                        devices.Add(HI);
                }
            }
            readyDevices = devices;
        }

        /// <summary>
        /// thread_doWork - called by the system in a new thread.  Do not call directly.
        /// Polls hardware inputs, sends resulting skeleton to Comm engine.
        /// </summary>
        public static SkeletonRep GetNewSkeleton()
        {
            //generate new skeleton
            SkeletonRep mod = new SkeletonRep();
            //ask each sensor the modify the skeleton as it sees fit
            foreach(SensorInterface s in readyDevices)
                s.ModifyModel(mod);
            return mod;
        }
    }
}
