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

        public override void ping(EventHandler<long> callback)
        {
            Stopwatch timer = new Stopwatch();
            EventHandler<string> protocallback = (object sender, string e) => {
                timer.Stop();
                callback(sender, timer.ElapsedMilliseconds);
            };
            timer.Start();
            commSock.SolicitResponse("ping", protocallback);
        }

        public override void requestData(string identifier, EventHandler<string> callback)
        {
            throw new NotImplementedException();
        }

        public override void updateSkeleton(SkeletonRep mod)
        {
            commSock.sendline("test mod.ShoulderLeft.Roll" + mod.ShoulderLeft.Roll.ToString());
        }

        public override void useNeutralSkeleton()
        {
            throw new NotImplementedException();
        }

        public override void useNullSkeleton()
        {
            throw new NotImplementedException();
        }

        public override void verifyRobot(EventHandler<bool> callback)
        {
            throw new NotImplementedException();
        }
    }
}
