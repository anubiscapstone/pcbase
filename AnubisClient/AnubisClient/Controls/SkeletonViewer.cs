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

        public override string GetHeloString()
        {
            return "SkeletonViewer";
        }

        public override void UpdateSkeleton(SkeletonRep mod)
        {
            String toSend = "";
            foreach(Joint3d j in mod.Joints)
            {
                toSend += j.X.ToString() + " ";
                toSend += j.Y.ToString() + " ";
            }
            commSock.SendLine(toSend);
        }
    }
}
