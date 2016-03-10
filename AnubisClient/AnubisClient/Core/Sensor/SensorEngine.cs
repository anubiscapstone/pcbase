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
    /// Module that manages the SensorInterfaces.
    /// Keeps references to all of the Sensors and can be asked to poll them all for a new Skeleton
    /// </summary>
    public static class SensorEngine
    {
        //List of sensor devices to be polled.
        private static List<SensorInterface> readyDevices = new List<SensorInterface>();

        /// <summary>
        /// Finds all of the devices that can be started
        /// </summary>
        public static void StartDevice(SensorInterface sensor)
        {
            sensor.StartDeviceServer();
            readyDevices.Add(sensor);
        }

        /// <summary>
        /// Finds all of the devices that can be started
        /// </summary>
        public static List<SensorInterface> DiscoverDevices()
        {
            List<SensorInterface> devices = new List<SensorInterface>();
            foreach(Type t in Assembly.GetAssembly(typeof(SensorInterface)).GetTypes())
            {
                if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(SensorInterface)))
                {
                    SensorInterface HI = (SensorInterface)Activator.CreateInstance(t);
                    if (HI.DetectDevice())
                        devices.Add(HI);
                }
            }
            return devices;
        }

        /// <summary>
        /// Request a new skeleton from the Sensors
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
