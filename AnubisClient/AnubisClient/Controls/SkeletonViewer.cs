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
            commSock.SendLine("test mod.ShoulderLeft.Roll" + mod.ShoulderLeft.Roll.ToString());
        }
    }
}
