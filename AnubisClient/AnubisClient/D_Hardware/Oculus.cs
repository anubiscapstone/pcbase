using SharpOVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Threading;

namespace AnubisClient.D_Hardware
{
    /// <summary>
    /// Encapsulates an Oculus Rift DK2 - used to get head tracking info.
    /// </summary>
    public class Oculus : HardwareInterface
    {
        private HMD oculus;
        private double YOffset, POffset;

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
                mod.Head.Pitch = 90 - ((pitch * 180) / Math.PI) ;
                if (YOffset == 0)
                {
                    YOffset = ((yaw * 180) / Math.PI);
                }
                mod.Head.Yaw = 90 - ((yaw * 180) / Math.PI) + YOffset;
                if (mod.Head.Yaw < 0)
                {
                    mod.Head.Yaw += 360;
                } else if (mod.Head.Yaw > 360)
                {
                    mod.Head.Yaw -= 360;
                }
        }

        public override bool detectDevice()
        {
            startDeviceServer();
            OVR.Initialize();
            oculus = OVR.HmdCreate(0);
            if (oculus == null)
            {
                return false;
            }
            oculus.ConfigureTracking(TrackingCapabilities.Orientation | TrackingCapabilities.MagYawCorrection, TrackingCapabilities.None);
            //float yaw = 0, roll = 0, pitch = 0;
            //oculus.GetEyePose(0).Orientation.GetEulerAngles(out yaw, out pitch, out roll);
            //YOffset =((yaw * 180) / Math.PI);
            //POffset =(((yaw - YOffset) * 180) / Math.PI);
            //oculus.RecenterPose();
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
            Process[] pname = Process.GetProcessesByName("VrPlayer");
            if (pname.Length == 0)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.FileName = "C:\\Program Files (x86)\\VR Player\\VRPlayer.exe";   //this is the old location
                startInfo.FileName = "C:\\Users\\admin\\Desktop\\Anubis Project\\PCBase\\VRPlayer\\VrPlayer\\bin\\Debug\\VrPlayer.exe";  //this is the new location with Drew's changes
                //startInfo.Arguments = s;//s would be a string parameter passed into this function
                Process.Start(startInfo);
            }
        }

        public override System.Windows.Forms.Form getForm()
        {
            return new Oculus_Form(this);
        }
    }
}
