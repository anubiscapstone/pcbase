﻿using System;
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
            // POLICY_BACKGROUND_FRAMES allows for the application to continuously track even when the application is in the background
            controller.SetPolicy(Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES);
            listener = new LeapEventListener();
        }

        private class LeapEventListener : Listener
        {
            public Hand trackedLeft = null;
            public Hand trackedRight = null;

            // This method is called each time the Event Listener is notified of a new Frame Object
            public override void OnFrame(Controller controller)
            {
                Hand tempLeft = null;
                Hand tempRight = null;

                // This loop begins when a hand object enters the scope of the device, it then determines if its a Left or Right hand 
                // and sets the value of that hand to its corresponding hand variable
                foreach (Hand h in controller.Frame().Hands)
                {
                    if ((tempLeft == null) && (h.IsLeft))
                    {
                        tempLeft = h;
                    }

                    if ((tempRight == null) && (h.IsRight))
                    {
                        tempRight = h;
                    }
                }

                trackedLeft = tempLeft;
                trackedRight = tempRight;
            }

        }

        public override void ModifyModel(SkeletonRep mod)
        {
            if (!IsTracking())
                return;

            Hand tempLeft = listener.trackedLeft;
            Hand tempRight = listener.trackedRight;

            if (tempLeft != null)
            {
                // Sets values for SkeletonRep X, Y, Z, & Tracked
                foreach (Finger f in tempLeft.Fingers)
                {
                    
                    switch (f.Type)
                    {
                        case Finger.FingerType.TYPE_THUMB:
                            mod.Joints[SkeletonRep.JointType.ThumbLeft].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.ThumbLeft].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.ThumbLeft].Z = f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.ThumbLeft].Tracked = true;
                            break;
                        case Finger.FingerType.TYPE_INDEX:
                            mod.Joints[SkeletonRep.JointType.IndexLeft].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.IndexLeft].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.IndexLeft].Z= f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.IndexLeft].Tracked = true;
                            break;
                        case Finger.FingerType.TYPE_MIDDLE:
                            mod.Joints[SkeletonRep.JointType.MiddleLeft].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.MiddleLeft].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.MiddleLeft].Z =  f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.MiddleLeft].Tracked = true;
                            break;
                        case Finger.FingerType.TYPE_RING:
                            mod.Joints[SkeletonRep.JointType.RingLeft].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.RingLeft].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.RingLeft].Z = f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.RingLeft].Tracked = true;
                            break;
                        case Finger.FingerType.TYPE_PINKY:
                            mod.Joints[SkeletonRep.JointType.PinkyLeft].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.PinkyLeft].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.PinkyLeft].Z = f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.PinkyLeft].Tracked = true;
                            break;
                    }
                }
            }

            if (tempRight != null)
            {
                // Sets values for SkeletonRep X, Y, Z, & Tracked
                foreach (Finger f in tempRight.Fingers)
                {

                    switch (f.Type)
                    {
                        case Finger.FingerType.TYPE_THUMB:
                            mod.Joints[SkeletonRep.JointType.ThumbRight].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.ThumbRight].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.ThumbRight].Z = f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.ThumbRight].Tracked = true;
                            break;
                        case Finger.FingerType.TYPE_INDEX:
                            mod.Joints[SkeletonRep.JointType.IndexRight].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.IndexRight].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.IndexRight].Z = f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.IndexRight].Tracked = true;
                            break;
                        case Finger.FingerType.TYPE_MIDDLE:
                            mod.Joints[SkeletonRep.JointType.MiddleRight].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.MiddleRight].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.MiddleRight].Z = f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.MiddleRight].Tracked = true;
                            break;
                        case Finger.FingerType.TYPE_RING:
                            mod.Joints[SkeletonRep.JointType.RingRight].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.RingRight].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.RingRight].Z = f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.RingRight].Tracked = true;
                            break;
                        case Finger.FingerType.TYPE_PINKY:
                            mod.Joints[SkeletonRep.JointType.PinkyRight].X = f.TipPosition.x;
                            mod.Joints[SkeletonRep.JointType.PinkyRight].Y = f.TipPosition.y;
                            mod.Joints[SkeletonRep.JointType.PinkyRight].Z = f.TipPosition.z;
                            mod.Joints[SkeletonRep.JointType.PinkyRight].Tracked = true;
                            break;
                    }
                }
            }
        }

        public override bool DetectDevice()
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

        public override void StartDeviceTracking()
        {
            if (IsTracking())
                return;
            controller.AddListener(listener);
            tracking = true;
        }

        public override string Name()
        {
            return "Leap Motion";
        }

        private bool tracking = false;

        public override bool IsTracking()
        {
            return tracking;
        }

        public override void StopDeviceTracking()
        {
            if (!IsTracking())
                return;
            controller.RemoveListener(listener);
            tracking = false;
        }
    }
}
