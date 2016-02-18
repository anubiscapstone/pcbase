using SharpOVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Threading;

namespace AnubisClient
{
    /// <summary>
    /// Encapsulates an Oculus Rift DK2 - used to get head tracking info.
    /// </summary>
    public class Oculus : SensorInterface
    {
        private HMD oculus;
        private double YOffset;

        public override bool DetectDevice()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "C:\\Program Files (x86)\\Oculus\\Service\\OVRServer_x64.exe";
                Process.Start(startInfo);

                //start the Oculus
                OVR.Initialize();
                oculus = OVR.HmdCreate(0);
                if (oculus == null)
                {
                    return false;
                }
            }
            catch (Exception ex) { return false; }
            return true;
        }

        public override void StartDeviceServer()
        {
            //Start tracking
            if(oculus != null)
                oculus.ConfigureTracking(TrackingCapabilities.Orientation | TrackingCapabilities.MagYawCorrection, TrackingCapabilities.None);
        }

        public override void ModifyModel(SkeletonRep mod)
        {

            float yaw = 0, pitch = 0, roll = 0;
            //Get the angle of the head mounted display.
            oculus.GetEyePose(0).Orientation.GetEulerAngles(out yaw, out pitch, out roll);
            //convert the pitch from radians to degrees
            mod.Joints[SkeletonRep.JointType.Head].Pitch = 90 - ((pitch * 180) / Math.PI);
            //If YOffset has not yet been initialized, do so now. 
            if (YOffset == 0)
            {
                YOffset = ((yaw * 180) / Math.PI);
            }
            //convert Yaw from radians to degrees
            mod.Joints[SkeletonRep.JointType.Head].Yaw = 90 - ((yaw * 180) / Math.PI) + YOffset;
            //Correct the angle of the headset by applying YOffset.  This is done to 
            //make certain the robot's head will always be oriented forward on startup.
            if (mod.Joints[SkeletonRep.JointType.Head].Yaw < 0)
            {
                mod.Joints[SkeletonRep.JointType.Head].Yaw += 360;
            }
            else if (mod.Joints[SkeletonRep.JointType.Head].Yaw > 360)
            {
                mod.Joints[SkeletonRep.JointType.Head].Yaw -= 360;
            }
            mod.Joints[SkeletonRep.JointType.Head].Tracked = true;
        }
    }
}
