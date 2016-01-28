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
            toSend += mod.Head.Pitch.ToString() + " ";
            toSend += mod.Head.Yaw.ToString() + " ";
            toSend += mod.SpineShoulder.Pitch.ToString() + " ";
            toSend += mod.SpineShoulder.Yaw.ToString() + " ";
            toSend += mod.SpineMiddle.Pitch.ToString() + " ";
            toSend += mod.SpineMiddle.Yaw.ToString() + " ";
            toSend += mod.SpineBase.Pitch.ToString() + " ";
            toSend += mod.SpineBase.Yaw.ToString() + " ";
            toSend += mod.ShoulderLeft.Pitch.ToString() + " ";
            toSend += mod.ShoulderLeft.Yaw.ToString() + " ";
            toSend += mod.ShoulderRight.Pitch.ToString() + " ";
            toSend += mod.ShoulderRight.Yaw.ToString() + " ";
            toSend += mod.ElbowLeft.Pitch.ToString() + " ";
            toSend += mod.ElbowLeft.Yaw.ToString() + " ";
            toSend += mod.ElbowRight.Pitch.ToString() + " ";
            toSend += mod.ElbowRight.Yaw.ToString() + " ";
            toSend += mod.WristLeft.Pitch.ToString() + " ";
            toSend += mod.WristLeft.Yaw.ToString() + " ";
            toSend += mod.WristRight.Pitch.ToString() + " ";
            toSend += mod.WristRight.Yaw.ToString() + " ";
            toSend += mod.HandLeft.Pitch.ToString() + " ";
            toSend += mod.HandLeft.Yaw.ToString() + " ";
            toSend += mod.HandRight.Pitch.ToString() + " ";
            toSend += mod.HandRight.Yaw.ToString() + " ";
            toSend += mod.HipLeft.Pitch.ToString() + " ";
            toSend += mod.HipLeft.Yaw.ToString() + " ";
            toSend += mod.HipRight.Pitch.ToString() + " ";
            toSend += mod.HipRight.Yaw.ToString() + " ";
            toSend += mod.KneeLeft.Pitch.ToString() + " ";
            toSend += mod.KneeLeft.Yaw.ToString() + " ";
            toSend += mod.KneeRight.Pitch.ToString() + " ";
            toSend += mod.KneeRight.Yaw.ToString() + " ";
            toSend += mod.AnkleLeft.Pitch.ToString() + " ";
            toSend += mod.AnkleLeft.Yaw.ToString() + " ";
            toSend += mod.AnkleRight.Pitch.ToString() + " ";
            toSend += mod.AnkleRight.Yaw.ToString() + " ";
            toSend += mod.FootLeft.Pitch.ToString() + " ";
            toSend += mod.FootLeft.Yaw.ToString() + " ";
            toSend += mod.FootRight.Pitch.ToString() + " ";
            toSend += mod.FootRight.Yaw.ToString();
            commSock.SendLine(toSend);
        }
    }
}
