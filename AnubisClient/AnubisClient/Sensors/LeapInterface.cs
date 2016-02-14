using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;


namespace AnubisClient.Sensors
{
    public class LeapInterface : SensorInterface
    {
        Controller controller;
        LeapEventListener listener;
        public LeapInterface()
        {
            controller = new Controller();
            listener = new LeapEventListener();
        }

        private class LeapEventListener : Listener
        {
            public Boolean lt_tracked = false;
            public float lt_x;
            public override void OnFrame(Controller controller)
            {
                base.OnFrame(controller);

                Hand trackedLeft = null;
                Hand trackedRight = null;

                lt_tracked = false;

                foreach (Hand h in controller.Frame().Hands)
                {
                    if ((trackedLeft == null) && (h.IsLeft))
                    {
                        lt_tracked = true;
                        trackedLeft = h;
                    }

                    if ((trackedRight == null) && (h.IsRight))
                    {
                        trackedRight = h;
                    }
                }

                if (trackedLeft != null)
                {
                    foreach (Finger f in trackedLeft.Fingers)
                    {
                        switch (f.Type)
                        {
                            case Finger.FingerType.TYPE_THUMB:
                                lt_x = f.TipPosition.x;
                                break;
                            //case Finger.FingerType.TYPE_INDEX:

                            //case Finger.FingerType.TYPE_MIDDLE:

                            //case Finger.FingerType.TYPE_PINKY:

                        }
                    }
                }

            }

            }

        public void newFrameHandler(Leap.Frame frame)
        {
           
        }

        public override string getIdentString()
        {
            return "Leap Motion";
        }

        public override void modifyModel(SkeletonRep mod)
        {
            if (listener.lt_tracked)
            {

                mod.Joints[SkeletonRep.JointType.ThumbLeft].X = listener.lt_x;
            }
        }

        public override bool detectDevice()
        {

            foreach (var d in controller.Devices)
            {
                if (d.IsStreaming)
                {
                    return true;
                }
            }
            return false;
        }

        public override void startDeviceServer()
        {
            controller.AddListener(listener);
        }
    }
}
