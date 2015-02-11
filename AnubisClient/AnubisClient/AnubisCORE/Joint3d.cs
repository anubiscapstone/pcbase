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
            if (InitcenterSkel) {pitch = yaw = roll = 90; }
            
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
