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
        /// Provides an interface to request skeleton data from Sensors
        /// </summary>
        public abstract bool DetectDevice();

        /// <summary>
        /// Provides an interface to request skeleton data from Sensors
        /// </summary>
        public abstract void StartDeviceServer();

        /// <summary>
        /// 
        /// </summary>
        public abstract void ModifyModel(SkeletonRep mod);
    }
}
