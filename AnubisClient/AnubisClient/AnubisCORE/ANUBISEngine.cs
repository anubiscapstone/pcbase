using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    /// <summary>
    /// Encapsulates all robot interaction functionality.  The only things outside of this class are the 
    /// standard Windows user interface.
    /// </summary>
    static class ANUBISEngine
    {
        private static List<HardwareInterface> ActiveHardware;
        /// <summary>
        /// Initialize starts the ANUBISENGINE.  Nothing happens before this is called. 
        /// Starts the Communications Engine and Kinematics Engine.
        /// </summary>
        public static void Initialize() //Already being called by Program.cs
        {
            
            CommunicationsEngine.initialize();
            CommunicationsEngine.startServer();

            KinematicsEngine.initialize();

            ActiveHardware = KinematicsEngine.GetActiveDevices();

        }

        public static List<HardwareInterface> GetActiveHardware()
        {
            return ActiveHardware;
        }

    }
}
