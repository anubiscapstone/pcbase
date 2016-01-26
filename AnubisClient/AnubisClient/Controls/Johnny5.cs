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
            if (angle < 0) return 600;
            if (angle > 180) return 2400;
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

        private void storeVector()
        {
            commSock.SendLine("sv " + createVector());
        }

        public override string getHeloString()
        {
            return "Johnny5";
        }

        public override void updateSkeleton(SkeletonRep mod)
        {
            servoPositions[13] = angleDecode(mod.Head.Yaw);
            servoPositions[16] = angleDecode(mod.Head.Pitch);

            servoPositions[8] = angleDecode(mod.ShoulderLeft.Roll);
            servoPositions[9] = angleDecode(mod.ShoulderLeft.Pitch);

            servoPositions[3] = angleDecode(mod.ShoulderRight.Roll);
            servoPositions[4] = angleDecode(mod.ShoulderRight.Pitch);

            servoPositions[14] = angleDecode(mod.FootRight.Pitch);
            servoPositions[15] = angleDecode(mod.FootLeft.Pitch);

            // more to come!

            storeVector();
        }
    }
}
