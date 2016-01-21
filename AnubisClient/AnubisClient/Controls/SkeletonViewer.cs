﻿using System;
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

        public override void ping(EventHandler<GenericEventArgs<long>> callback)
        {
            Stopwatch timer = new Stopwatch();
            EventHandler<GenericEventArgs<string>> protocallback = (object sender, GenericEventArgs<string> e) => {
                timer.Stop();
                callback(sender, new GenericEventArgs<long>(timer.ElapsedMilliseconds));
            };
            timer.Start();
            commSock.solicitResponse("ping", protocallback);
        }

        public override void requestData(string identifier, EventHandler<GenericEventArgs<string>> callback)
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

        public override void verifyRobot(EventHandler<GenericEventArgs<bool>> callback)
        {
            throw new NotImplementedException();
        }
    }
}