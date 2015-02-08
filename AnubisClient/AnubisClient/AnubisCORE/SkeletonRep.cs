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
            SpineBase = new Joint3d();
            SpineMiddle = new Joint3d();
            Head = new Joint3d();
            ShoulderLeft = new Joint3d();
            ElbowLeft = new Joint3d();
            WristLeft = new Joint3d();
            HandLeft = new Joint3d();
            ShoulderRight = new Joint3d();
            ElbowRight = new Joint3d();
            WristRight = new Joint3d();
            HandRight = new Joint3d();
            HipLeft = new Joint3d();
            KneeLeft = new Joint3d();
            AnkleLeft = new Joint3d();
            FootLeft = new Joint3d();
            HipRight = new Joint3d();
            KneeRight = new Joint3d();
            AnkleRight = new Joint3d();
        }
        
    }
}
