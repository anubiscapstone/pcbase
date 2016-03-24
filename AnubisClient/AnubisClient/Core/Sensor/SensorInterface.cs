using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnubisClient
{
    /// <summary>
    /// Provides an interface to request skeleton data from a Sensor
    /// </summary>
    public abstract class SensorInterface
    {
        /// <summary>
        /// Returns true if this Sensor can start tracking information
        /// </summary>
        public abstract bool DetectDevice();

        /// <summary>
        /// Returns true if this Sensor has started tracking
        /// </summary>
        public abstract bool IsTracking();

        /// <summary>
        /// Starts tracking information from this Sensor
        /// </summary>
        public abstract void StartDeviceTracking();

        /// <summary>
        /// Stops tracking information from this Sensor
        /// </summary>
        public abstract void StopDeviceTracking();

        /// <summary>
        /// Adds whatever information this Sensor tracks to the Skeleton
        /// </summary>
        public abstract void ModifyModel(SkeletonRep mod);

        /// <summary>
        /// Return friendly name for GUI purposes
        /// </summary>
        public abstract string Name();
    }
}
