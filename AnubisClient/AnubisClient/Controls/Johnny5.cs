using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AnubisClient
{
    /// <summary>
    /// Encapsulates an adapter to the Johnny5 robot
    /// Will translate the tracked skeleton data into servo positions to send to the actual robot to use
    /// </summary>
    public class Johnny5 : ControlInterface
    {
        //There are 17 servos (motors included) that can be controlled.
        //Each has a range [600,2400] with 1500 being the mid-point
        private int[] servoPositions = new int[17];

        public Johnny5(CommunicationsInterface commSock)
            : base(commSock)
        {
            //set all servos to the mid-point
            for (int i = 0; i < servoPositions.Length; i++)
                servoPositions[i] = 1500;
        }

        /// <summary>
        /// Translate angle (in degrees) to a servo value in the range [600,2400]
        /// </summary>
        private int angleDecode(double angle)
        {
            //clamp angle between 0 and 180 degrees
            angle = Math.Max(0, Math.Min(180, angle));
            //interpolate the angles into the servo values' space with the linear function servo = 10(angle) + 600
            return (int)(angle * 10) + 600;
        }

        /// <summary>
        /// Build the string that will be sent to the Johnny5 robot.
        /// This will be a space delimited list of servo values of the form "#{index}P{value}" or "#{index}L" if there is no value
        /// </summary>
        private string createVector()
        {
            string vec = "";

            for (int i = 0; i < servoPositions.Length; i++)
            {
                int pos = servoPositions[i];
                if (pos >= 0) vec += "#" + i.ToString() + " P" + pos + " ";
                else vec += "#" + i.ToString() + "L ";
            }

            vec += "\r";
            return vec;
        }

        /// <summary>
        /// Send the values off to the Johnny5 robot.
        /// </summary>
        private void storeVector()
        {
            commSock.SendLine("sv " + createVector());
        }

        public override string GetHeloString()
        {
            return "Johnny5";
        }

        public override void UpdateSkeleton(SkeletonRep mod)
        {
            //default values if any of the joints we care about aren't tracked
            double headAngleX = 90.0;
            double headAngleY = 90.0;
            double arm1AngleX = 90.0;
            double arm1AngleY = 90.0;
            double arm2AngleX = 90.0;
            double arm2AngleY = 90.0;
            double foot1Angle = 90.0;
            double foot2Angle = 90.0;
            
            // Hand 1 = Left, Hand 2 = Right
            double hand1Dist = 0;
            double hand2Dist = 0;

            if(mod.Joints[SkeletonRep.JointType.Head].Tracked)
            {
                headAngleX = mod.Joints[SkeletonRep.JointType.Head].Yaw;
                headAngleY = mod.Joints[SkeletonRep.JointType.Head].Pitch;
            }

            //Calculate the orientation (without roll) of the arms
            if (mod.Joints[SkeletonRep.JointType.ShoulderLeft].Tracked && mod.Joints[SkeletonRep.JointType.ElbowLeft].Tracked)
            {
                //Calculate the difference vector between the Elbow and the Shoulder
                double DX = -(mod.Joints[SkeletonRep.JointType.ElbowLeft].X - mod.Joints[SkeletonRep.JointType.ShoulderLeft].X);
                double DY = -(mod.Joints[SkeletonRep.JointType.ElbowLeft].Y - mod.Joints[SkeletonRep.JointType.ShoulderLeft].Y);
                double DZ = -(mod.Joints[SkeletonRep.JointType.ElbowLeft].Z - mod.Joints[SkeletonRep.JointType.ShoulderLeft].Z);
                //Figure out how much of our relative yaw is in the neutral yaw vs the neutral roll (depends on relative pitch)
                double lenAngleY = Math.Sqrt(Math.Pow(DY, 2) + Math.Pow(DZ, 2));
                //Calculate the relative yaw
                arm1AngleX = Math.Atan2(Math.Max(0, lenAngleY), DX) * (180 / Math.PI);
                //Figure out how much of our relative pitch is in the neutral pitch vs the neutral roll (depends on relative yaw)
                double lenAngleX = Math.Sqrt(Math.Pow(DX, 2) + Math.Pow(DZ, 2));
                //Calculate the relative pitch
                arm1AngleY = Math.Atan2(Math.Max(0, lenAngleX), DY) * (180 / Math.PI);
            }

            if (mod.Joints[SkeletonRep.JointType.ShoulderRight].Tracked && mod.Joints[SkeletonRep.JointType.ElbowRight].Tracked)
            {
                double DX = -(mod.Joints[SkeletonRep.JointType.ElbowRight].X - mod.Joints[SkeletonRep.JointType.ShoulderRight].X);
                double DY = mod.Joints[SkeletonRep.JointType.ElbowRight].Y - mod.Joints[SkeletonRep.JointType.ShoulderRight].Y;
                double DZ = -(mod.Joints[SkeletonRep.JointType.ElbowRight].Z - mod.Joints[SkeletonRep.JointType.ShoulderRight].Z);
                double lenAngleY = Math.Sqrt(Math.Pow(DY, 2) + Math.Pow(DZ, 2));
                arm2AngleX = Math.Atan2(Math.Max(0, lenAngleY), DX) * (180 / Math.PI);
                double lenAngleX = Math.Sqrt(Math.Pow(DX, 2) + Math.Pow(DZ, 2));
                arm2AngleY = Math.Atan2(Math.Max(0, lenAngleX), DY) * (180 / Math.PI);
            }

            if (mod.Joints[SkeletonRep.JointType.AnkleLeft].Tracked && mod.Joints[SkeletonRep.JointType.FootLeft].Tracked && mod.Joints[SkeletonRep.JointType.AnkleRight].Tracked && mod.Joints[SkeletonRep.JointType.FootRight].Tracked)
            {
                if (mod.Joints[SkeletonRep.JointType.FootLeft].Pitch != 0)
                    foot1Angle = mod.Joints[SkeletonRep.JointType.FootLeft].Pitch;
                if (mod.Joints[SkeletonRep.JointType.FootRight].Pitch != 0)
                    foot2Angle = mod.Joints[SkeletonRep.JointType.FootRight].Pitch;
            }

            if (mod.Joints[SkeletonRep.JointType.HandLeft].Tracked)
            {
                double DX = -(mod.Joints[SkeletonRep.JointType.MiddleLeft].X - mod.Joints[SkeletonRep.JointType.ThumbLeft].X);
                double DY = mod.Joints[SkeletonRep.JointType.MiddleLeft].Y - mod.Joints[SkeletonRep.JointType.ThumbLeft].Y;
                double DZ = -(mod.Joints[SkeletonRep.JointType.MiddleLeft].Z - mod.Joints[SkeletonRep.JointType.ThumbLeft].Z);

                hand1Dist = Math.Sqrt(Math.Pow(DX, 2) + Math.Pow(DY, 2) + Math.Pow(DZ, 2));
                System.Diagnostics.Debug.WriteLine("Hand 1: " + hand1Dist);
            }

            if (mod.Joints[SkeletonRep.JointType.HandRight].Tracked)
            {
                double DX = -(mod.Joints[SkeletonRep.JointType.MiddleRight].X - mod.Joints[SkeletonRep.JointType.ThumbRight].X);
                double DY = mod.Joints[SkeletonRep.JointType.MiddleRight].Y - mod.Joints[SkeletonRep.JointType.ThumbRight].Y;
                double DZ = -(mod.Joints[SkeletonRep.JointType.MiddleRight].Z - mod.Joints[SkeletonRep.JointType.ThumbRight].Z);

                hand2Dist = Math.Sqrt(Math.Pow(DX, 2) + Math.Pow(DY, 2) + Math.Pow(DZ, 2));
                System.Diagnostics.Debug.WriteLine("Hand 2: " + hand2Dist);
            }

            servoPositions[13] = angleDecode(headAngleX);
            servoPositions[16] = angleDecode(headAngleY);

            servoPositions[8] = angleDecode(arm1AngleY);
            servoPositions[9] = angleDecode(arm1AngleX);

            servoPositions[3] = angleDecode(arm2AngleY);
            servoPositions[4] = angleDecode(arm2AngleX);
            
            servoPositions[14] = angleDecode(foot2Angle);
            servoPositions[15] = angleDecode(foot1Angle);

            // Hand Servos min 1025, max 1975
            servoPositions[7] = (int)(1975 - (hand2Dist - 12)*(950/163));
            servoPositions[12] = (int)((hand1Dist - 12)*(950/163) + 1025);

            storeVector();
        }
    }
}
