using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    class SkeletonViewer : ControlInterface
    {
        public SkeletonViewer(CommunicationsInterface commSock) : base(commSock) {}

        public override string getHeloString()
        {
            return "SkeletonViewer";
        }

        public override void updateSkeleton(SkeletonRep mod)
        {
            String toSend = "";
            toSend += mod.Head.X.ToString() + " ";
            toSend += mod.Head.Y.ToString() + " ";
            toSend += mod.SpineShoulder.X.ToString() + " ";
            toSend += mod.SpineShoulder.Y.ToString() + " ";
            toSend += mod.SpineMiddle.X.ToString() + " ";
            toSend += mod.SpineMiddle.Y.ToString() + " ";
            toSend += mod.SpineBase.X.ToString() + " ";
            toSend += mod.SpineBase.Y.ToString() + " ";
            toSend += mod.ShoulderLeft.X.ToString() + " ";
            toSend += mod.ShoulderLeft.Y.ToString() + " ";
            toSend += mod.ShoulderRight.X.ToString() + " ";
            toSend += mod.ShoulderRight.Y.ToString() + " ";
            toSend += mod.ElbowLeft.X.ToString() + " ";
            toSend += mod.ElbowLeft.Y.ToString() + " ";
            toSend += mod.ElbowRight.X.ToString() + " ";
            toSend += mod.ElbowRight.Y.ToString() + " ";
            toSend += mod.WristLeft.X.ToString() + " ";
            toSend += mod.WristLeft.Y.ToString() + " ";
            toSend += mod.WristRight.X.ToString() + " ";
            toSend += mod.WristRight.Y.ToString() + " ";
            toSend += mod.HandLeft.X.ToString() + " ";
            toSend += mod.HandLeft.Y.ToString() + " ";
            toSend += mod.HandRight.X.ToString() + " ";
            toSend += mod.HandRight.Y.ToString() + " ";
            toSend += mod.HipLeft.X.ToString() + " ";
            toSend += mod.HipLeft.Y.ToString() + " ";
            toSend += mod.HipRight.X.ToString() + " ";
            toSend += mod.HipRight.Y.ToString() + " ";
            toSend += mod.KneeLeft.X.ToString() + " ";
            toSend += mod.KneeLeft.Y.ToString() + " ";
            toSend += mod.KneeRight.X.ToString() + " ";
            toSend += mod.KneeRight.Y.ToString() + " ";
            toSend += mod.AnkleLeft.X.ToString() + " ";
            toSend += mod.AnkleLeft.Y.ToString() + " ";
            toSend += mod.AnkleRight.X.ToString() + " ";
            toSend += mod.AnkleRight.Y.ToString() + " ";
            toSend += mod.FootLeft.X.ToString() + " ";
            toSend += mod.FootLeft.Y.ToString() + " ";
            toSend += mod.FootRight.X.ToString() + " ";
            toSend += mod.FootRight.Y.ToString();
            commSock.SendLine(toSend);
        }
    }
}
