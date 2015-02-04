using SharpOVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows;

namespace AnubisClient.D_Hardware
{
    public class Oculus : HardwareInterface
    {
        private HMD oculus;

        public Oculus()
        {

        }

        public override string getIdentString()
        {
            return "Oculus";
        }

        public override void modifyModel(SkeletonRep mod)
        {

                float yaw = 0, pitch = 0, roll = 0;
                oculus.GetEyePose(0).Orientation.GetEulerAngles(out yaw, out pitch, out roll);
                mod.Head.Pitch = 90 - ((pitch * 180) / Math.PI);
                mod.Head.Yaw = 90 - ((yaw * 180) / Math.PI);
        }

        public override bool detectDevice()
        {
            OVR.Initialize();
            oculus = OVR.HmdCreate(0); 
            if (oculus == null)
            {
                return false;
            }
            oculus.ConfigureTracking(TrackingCapabilities.Orientation | TrackingCapabilities.MagYawCorrection, TrackingCapabilities.None);
            return true;
        }

        public override void startDeviceServer()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "C:\\Program Files (x86)\\Oculus\\Service\\OVRServer_x64.exe";
            //startInfo.Arguments = s;//s would be a string parameter passed into this function
            Process.Start(startInfo);
        }

        public void OpenVRPlayer()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "C:\\Program Files (x86)\\VR Player\\VRPlayer.exe";
            //startInfo.Arguments = s;//s would be a string parameter passed into this function
            Process.Start(startInfo);
        }
    }
}
