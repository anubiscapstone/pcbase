using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    /// <summary>
    /// A collection of all of the information we track about the user.
    /// Sensors and the GestureEngine will create and modify these.
    /// Controls will interperet this information within the context of their application.
    /// The coordinate space of a joint is specific to that joint.
    /// </summary>
    public class SkeletonRep
    {
        /// <summary>
        ///Any joints that can be tracked should be in this list.
        ///Whether they are tracked and whether they are needed is up to the Sensors and Controls
        /// </summary>
        public enum JointType : int
        {
            Head,
            ShoulderCenter,
            ShoulderLeft,
            ShoulderRight,
            ElbowLeft,
            ElbowRight,
            WristLeft,
            WristRight,
            HandLeft,
            HandRight,
            Spine,
            HipCenter,
            HipLeft,
            HipRight,
            KneeLeft,
            KneeRight,
            AnkleLeft,
            AnkleRight,
            FootLeft,
            FootRight,
            ThumbRight,
            ThumbLeft,
            IndexRight,
            IndexLeft,
            MiddleRight,
            MiddleLeft,
            RingRight,
            RingLeft,
            PinkyRight,
            PinkyLeft

        }
        /// <summary>
        /// Provides an enumerable interface to a collection of Joint3Ds
        /// It is accesible by the JointType enum
        /// </summary>
        public class JointCollection : IEnumerable<Joint3d>
        {
            private Joint3d[] Joints = new Joint3d[Enum.GetValues(typeof(JointType)).Length];

            public Joint3d this[JointType j]
            {
                get { return Joints[(int)j]; }
                set { Joints[(int)j] = value; }
            }

            public Joint3d this[int i]
            {
                get { return Joints[i]; }
                set { Joints[i] = value; }
            }

            public IEnumerator<Joint3d> GetEnumerator()
            {
                return Joints.AsEnumerable().GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        public JointCollection Joints;

        public SkeletonRep()
        {
            Joints = new JointCollection();
            Neutralize();
        }

        /// <summary>
        /// Sets all of the skeleton's joints to a "neutral" position.
        /// The neutral position of a joint is specific to that joint.
        /// No orientation information is set here.
        /// </summary>
        public void Neutralize()
        {
            //Reset all joints
            int len = Enum.GetValues(typeof(JointType)).Length;
            for (int i = 0; i < len; i++)
                Joints[i] = new Joint3d();

            //A simple "standing man" configuration within [-1,1] in all three dimensions.
            //No orientations are set here.
            //Joints[JointType.Spine] is center at (0, 0, 0)

            Joints[JointType.HipCenter].Y = Joints[JointType.Spine].Y - 0.3;
            Joints[JointType.ShoulderCenter].Y = Joints[JointType.Spine].Y + 0.3;
            Joints[JointType.Head].Y = Joints[JointType.ShoulderCenter].Y + 0.1;

            Joints[JointType.ShoulderLeft].Y = Joints[JointType.ShoulderCenter].Y;
            Joints[JointType.ShoulderLeft].X = Joints[JointType.ShoulderCenter].X - 0.2;

            Joints[JointType.ShoulderRight].Y = Joints[JointType.ShoulderCenter].Y;
            Joints[JointType.ShoulderRight].X = Joints[JointType.ShoulderCenter].X + 0.2;

            Joints[JointType.ElbowLeft].Y = Joints[JointType.ShoulderLeft].Y - 0.3;
            Joints[JointType.ElbowLeft].X = Joints[JointType.ShoulderLeft].X;

            Joints[JointType.ElbowRight].Y = Joints[JointType.ShoulderRight].Y - 0.3;
            Joints[JointType.ElbowRight].X = Joints[JointType.ShoulderRight].X;

            Joints[JointType.WristLeft].Y = Joints[JointType.ElbowLeft].Y - 0.3;
            Joints[JointType.WristLeft].X = Joints[JointType.ElbowLeft].X;

            Joints[JointType.WristRight].Y = Joints[JointType.ElbowRight].Y - 0.3;
            Joints[JointType.WristRight].X = Joints[JointType.ElbowRight].X;

            Joints[JointType.HandLeft].Y = Joints[JointType.WristLeft].Y - 0.1;
            Joints[JointType.HandLeft].X = Joints[JointType.WristLeft].X;
            
            Joints[JointType.HandRight].Y = Joints[JointType.WristRight].Y - 0.1;
            Joints[JointType.HandRight].X = Joints[JointType.WristRight].X;

            Joints[JointType.HipLeft].Y = Joints[JointType.HipCenter].Y;
            Joints[JointType.HipLeft].X = Joints[JointType.HipCenter].X - 0.15;

            Joints[JointType.HipRight].Y = Joints[JointType.HipCenter].Y;
            Joints[JointType.HipRight].X = Joints[JointType.HipCenter].X + 0.15;

            Joints[JointType.KneeLeft].Y = Joints[JointType.HipLeft].Y - 0.3;
            Joints[JointType.KneeLeft].X = Joints[JointType.HipLeft].X;

            Joints[JointType.KneeRight].Y = Joints[JointType.HipRight].Y - 0.3;
            Joints[JointType.KneeRight].X = Joints[JointType.HipRight].X;

            Joints[JointType.AnkleLeft].Y = Joints[JointType.KneeLeft].Y - 0.3;
            Joints[JointType.AnkleLeft].X = Joints[JointType.KneeLeft].X;

            Joints[JointType.AnkleRight].Y = Joints[JointType.KneeRight].Y - 0.3;
            Joints[JointType.AnkleRight].X = Joints[JointType.KneeRight].X;

            Joints[JointType.FootLeft].Y = Joints[JointType.AnkleLeft].Y;
            Joints[JointType.FootLeft].X = Joints[JointType.AnkleLeft].X;
            Joints[JointType.FootLeft].Z = Joints[JointType.AnkleLeft].Z + 0.1;

            Joints[JointType.FootRight].Y = Joints[JointType.AnkleRight].Y;
            Joints[JointType.FootRight].X = Joints[JointType.AnkleRight].X;
            Joints[JointType.FootRight].Z = Joints[JointType.AnkleRight].Z + 0.1;
        }
    }
}
