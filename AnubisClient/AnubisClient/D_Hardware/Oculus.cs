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
                //Get the angle of the head mounted display.
                oculus.GetEyePose(0).Orientation.GetEulerAngles(out yaw, out pitch, out roll);
                //convert the pitch from radians to degrees
                mod.Head.Pitch = 90 - ((pitch * 180) / Math.PI) ;
                //If YOffset has not yet been initialized, do so now. 
                if (YOffset == 0)
                {
                    YOffset = ((yaw * 180) / Math.PI);
                }
                //convert Yaw from radians to degrees
                mod.Head.Yaw = 90 - ((yaw * 180) / Math.PI) + YOffset;
                //Correct the angle of the headset by applying YOffset.  This is done to 
                //make certain the robot's head will always be oriented forward on startup.
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
            //start the Oculus
            OVR.Initialize();
            oculus = OVR.HmdCreate(0);
            if (oculus == null)
            {
                return false;
            }
            //Start tracking
            oculus.ConfigureTracking(TrackingCapabilities.Orientation | TrackingCapabilities.MagYawCorrection, TrackingCapabilities.None);
            return true;
        }

        public override void startDeviceServer()
        {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "C:\\Program Files (x86)\\Oculus\\Service\\OVRServer_x64.exe";
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
                Process.Start(startInfo);
            }
        }

        public override System.Windows.Forms.Form getForm()
        {
            return new Oculus_Form(this);
        }
    }
}
