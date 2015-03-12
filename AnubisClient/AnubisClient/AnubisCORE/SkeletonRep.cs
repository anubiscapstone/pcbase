using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    /// <summary>
    /// Represents a skeleton, the object used to pass user information between input devices and output device drivers.
    /// </summary>
    public class SkeletonRep
    {
        public Joint3d SpineBase, SpineMiddle, Head, ShoulderLeft, ElbowLeft, WristLeft, HandLeft, ShoulderRight, ElbowRight, WristRight, HandRight, HipLeft, KneeLeft, AnkleLeft, FootLeft, HipRight, KneeRight, AnkleRight;
        public Joint3d FootRight, SpineShoulder;

        public SkeletonRep()
        {
            SpineBase = new Joint3d(true);
            SpineMiddle = new Joint3d(true);
            Head = new Joint3d(true);
            ShoulderLeft = new Joint3d(true);
            ShoulderLeft.Roll = 0;
            ElbowLeft = new Joint3d(true);
            WristLeft = new Joint3d(true);
            HandLeft = new Joint3d(true);
            ShoulderRight = new Joint3d(true);
            ShoulderRight.Roll = 0;
            ElbowRight = new Joint3d(true);
            WristRight = new Joint3d(true);
            HandRight = new Joint3d(true);
            HipLeft = new Joint3d(true);
            KneeLeft = new Joint3d(true);
            AnkleLeft = new Joint3d(true);
            FootLeft = new Joint3d(true);
            HipRight = new Joint3d(true);
            KneeRight = new Joint3d(true);
            AnkleRight = new Joint3d(true);
            FootRight = new Joint3d(true);
            SpineShoulder = new Joint3d(true);


        }
        
    }
}
