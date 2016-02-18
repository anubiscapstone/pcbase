using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AnubisClient {
    public class Johnny5 : ControlInterface
    {
        private int[] servoPositions;

        public Johnny5(CommunicationsInterface commSock)
            : base(commSock)
        {
            servoPositions = new int[17];
            for (int i = 0; i < servoPositions.Length; i++)
            {
                servoPositions[i] = 1500;
            }
        }

        private int angleDecode(double angle)
        {
            angle = Math.Max(0, Math.Min(180, angle));
            return (int)(angle * 10) + 600;
        }

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

            if(mod.Joints[SkeletonRep.JointType.Head].Tracked)
            {
                headAngleX = mod.Joints[SkeletonRep.JointType.Head].Yaw;
                headAngleY = mod.Joints[SkeletonRep.JointType.Head].Pitch;
            }

            if (mod.Joints[SkeletonRep.JointType.ShoulderLeft].Tracked && mod.Joints[SkeletonRep.JointType.ElbowLeft].Tracked)
            {
                double DX = -(mod.Joints[SkeletonRep.JointType.ElbowLeft].X - mod.Joints[SkeletonRep.JointType.ShoulderLeft].X);
                double DY = -(mod.Joints[SkeletonRep.JointType.ElbowLeft].Y - mod.Joints[SkeletonRep.JointType.ShoulderLeft].Y);
                double DZ = -(mod.Joints[SkeletonRep.JointType.ElbowLeft].Z - mod.Joints[SkeletonRep.JointType.ShoulderLeft].Z);
                double lenAngleY = Math.Sqrt(Math.Pow(DY, 2) + Math.Pow(DZ, 2));
                arm1AngleX = Math.Atan2(Math.Max(0, lenAngleY), DX) * (180 / Math.PI);
                double lenAngleX = Math.Sqrt(Math.Pow(DX, 2) + Math.Pow(DZ, 2));
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

            servoPositions[13] = angleDecode(headAngleX);
            servoPositions[16] = angleDecode(headAngleY);

            servoPositions[8] = angleDecode(arm1AngleY);
            servoPositions[9] = angleDecode(arm1AngleX);

            servoPositions[3] = angleDecode(arm2AngleY);
            servoPositions[4] = angleDecode(arm2AngleX);
            
            servoPositions[14] = angleDecode(foot2Angle);
            servoPositions[15] = angleDecode(foot1Angle);

            storeVector();
        }
    }
}
