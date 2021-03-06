﻿using SharpOVR;
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
    /// Encapsulates an adapter to the Oculus Rift
    /// Will take the head information tracked by an Oculus Rift, translate it for our own internal use in ANUBIS, and modify a skeleton with that information when requested
    /// </summary>
    public class Oculus : SensorInterface
    {
        private HMD oculus;
        private double YOffset;

        private bool Initialized = false;

        private void Initialize()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "C:\\Program Files (x86)\\Oculus\\Service\\OVRServer_x64.exe";
                Process.Start(startInfo);

                //start the Oculus
                OVR.Initialize();
            }
            catch (Exception) {
                Initialized = false;
                return;
            }
            Initialized = true;
        }

        public Oculus()
        {
            Initialize();
        }

        public override bool DetectDevice()
        {
            if(!Initialized)
                Initialize();
            if (Initialized && (IsTracking() || OVR.HmdDetect() > 0))
                return true;
            return false;
        }

        public override void StartDeviceTracking()
        {
            //Start tracking
            if (Initialized && !IsTracking())
            {
                oculus = OVR.HmdCreate(0);
                if (oculus != null)
                    oculus.ConfigureTracking(TrackingCapabilities.Orientation | TrackingCapabilities.MagYawCorrection, TrackingCapabilities.None);
            }
        }

        public override void ModifyModel(SkeletonRep mod)
        {
            if (!IsTracking())
                return;
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

        public override string Name()
        {
            return "Oculus Rift";
        }

        public override bool IsTracking()
        {
            return oculus != null;
        }

        public override void StopDeviceTracking()
        {
            oculus = null;
        }
    }
}
