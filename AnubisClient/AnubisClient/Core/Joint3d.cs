using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    /// <summary>
    /// Joint3D - models a single skeletal joint, with angles in relation to attached joints.
    /// </summary>
    public class Joint3d
    {
        public Joint3d(bool InitcenterSkel)
        {
            if (InitcenterSkel) { x = y = z = 0; pitch = yaw = roll = 90; }
            
        }
        private double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private double z;
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        private double pitch;
        public double Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }

        private double yaw;
        public double Yaw
        {
            get { return yaw; }
            set { yaw = value; }
        }

        private double roll;
        public double Roll
        {
            get { return roll; }
            set { roll = value; }
        }

    }
}
