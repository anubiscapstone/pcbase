using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Timers;

namespace AnubisClient
{
    class Stoplight : ControlInterface
    {
        private Timer tmr;

        public Stoplight(CommunicationsEngine commDriver, CommunicationsInterface commSock)
            : base(commDriver, commSock)
        {
            tmr = new Timer(2000);
            tmr.Elapsed += new ElapsedEventHandler(reset);
            tmr.Start();
        }

        private void reset(Object sender, ElapsedEventArgs e)
        {
            tmr.Stop();
            sock_sendline_sync("e");
        }

        private void renew()
        {
            tmr.Stop();
            tmr.Start();
            sock_sendline_sync("s");
        }

        public override string getHeloString()
        {
            return "Stoplight";
        }

        public override void updateSkeleton(SkeletonRep mod)
        {
            renew();
        }

        public override void useNeutralSkeleton()
        {
            // ignore
        }

        public override void useNullSkeleton()
        {
            // ignore
        }

        public override void verifyRobot(EventHandler<GenericEventArgs<bool>> callback)
        {
            // Not Used
            callback(this, new GenericEventArgs<bool>(false));
        }

        public override void requestData(string identifier, EventHandler<GenericEventArgs<string>> callback)
        {
            // Not Used
            callback(this, new GenericEventArgs<string>(""));
        }

        public override void ping(EventHandler<GenericEventArgs<long>> callback)
        {
            Stopwatch timer = new Stopwatch();
            EventHandler<GenericEventArgs<string>> protocallback = (object sender, GenericEventArgs<string> e) =>
            {
                timer.Stop();
                callback(sender, new GenericEventArgs<long>(timer.ElapsedMilliseconds));
            };
            timer.Start();
            sock_invokeProto_solicitRobotResponse_async("pg", protocallback);
        }
    }
}
