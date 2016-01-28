using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    /// <summary>
    /// Joint3D - models a single skeletal joint.
    /// </summary>
    public class Joint3d
    {
        public Joint3d() {}

        public bool Tracked = false;

        public double X = 0.0;
        public double Y = 0.0;
        public double Z = 0.0;

        public double Pitch = 0.0;
        public double Yaw = 0.0;
        public double Roll = 0.0;
    }
}
