using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    /// <summary>
    /// Joint3D - Models a single skeletal joint.
    /// Whether a joint is tracked and what properties of it that are tracked is Sensor specific.
    /// </summary>
    public class Joint3d
    {
        public bool Tracked = false;

        public double X = 0.0;
        public double Y = 0.0;
        public double Z = 0.0;

        public double Pitch = 0.0;
        public double Yaw = 0.0;
        public double Roll = 0.0;
    }
}
