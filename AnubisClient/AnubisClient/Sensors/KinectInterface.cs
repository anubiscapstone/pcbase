using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;

namespace AnubisClient
{
    /// <summary>
    /// Encapsulates an adapter to the Microsoft Kinect
    /// Will take a single skeleton tracked by a Kinect, translate it for our own internal use in ANUBIS, and modify a skeleton with that information when requested
    /// </summary>
    public class KinectInterface : SensorInterface
    {
        private KinectSensor Sensor;
        private SkeletonRep Skeleton;
        private Boolean useNeutralSkeleton = true;

        public override bool DetectDevice()
        {
            //Looks for a connected Kinect and returns true if one is found.
            foreach (var potential in KinectSensor.KinectSensors)
            {
                if (potential.Status == KinectStatus.Connected)
                {
                    Sensor = potential;
                    return true;
                }
            }
            return false;
        }

        public override void StartDeviceServer()
        {
            //Sets up the Kinect to start tracking, hooks the new frame event, and starts the tracking
            if (Sensor != null)
            {
                Sensor.SkeletonStream.Enable();
                Sensor.SkeletonFrameReady += this.Sensor_SkeletonFrameReady;

                try
                {
                    Sensor.Start();
                }
                catch (IOException){}
            }
        }

        /// <summary>
        /// Event Handler for new frame events for the Kinect
        /// </summary>
        void Sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            SkeletonRep Skeleton = new SkeletonRep();

            Skeleton[] skeletons = new Skeleton[0];

            useNeutralSkeleton = true;
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if(skeletonFrame != null && skeletonFrame.SkeletonArrayLength > 0)
                {
                    //Copy Skeleton data to placeholder
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);

                    //Update joint position information
                    foreach (Skeleton s in skeletons)
                    {

                        if (s.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            useNeutralSkeleton = false;

                            JointCollection jnts = s.Joints;

                            Skeleton.Joints[SkeletonRep.JointType.ShoulderCenter].Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.ShoulderLeft]  .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.ShoulderRight] .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.ElbowLeft]     .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.ElbowRight]    .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.WristLeft]     .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.WristRight]    .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.HandLeft]      .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.HandRight]     .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.Spine]         .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.HipCenter]     .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.HipLeft]       .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.HipRight]      .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.KneeLeft]      .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.KneeRight]     .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.AnkleLeft]     .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.AnkleRight]    .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.FootLeft]      .Tracked = true;
                            Skeleton.Joints[SkeletonRep.JointType.FootRight]     .Tracked = true;

                            Skeleton.Joints[SkeletonRep.JointType.ShoulderCenter].X = jnts[JointType.ShoulderCenter].Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.ShoulderLeft]  .X = jnts[JointType.ShoulderLeft]  .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.ShoulderRight] .X = jnts[JointType.ShoulderRight] .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.ElbowLeft]     .X = jnts[JointType.ElbowLeft]     .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.ElbowRight]    .X = jnts[JointType.ElbowRight]    .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.WristLeft]     .X = jnts[JointType.WristLeft]     .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.WristRight]    .X = jnts[JointType.WristRight]    .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.HandLeft]      .X = jnts[JointType.HandLeft]      .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.HandRight]     .X = jnts[JointType.HandRight]     .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.Spine]         .X = jnts[JointType.Spine]         .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.HipCenter]     .X = jnts[JointType.HipCenter]     .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.HipLeft]       .X = jnts[JointType.HipLeft]       .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.HipRight]      .X = jnts[JointType.HipRight]      .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.KneeLeft]      .X = jnts[JointType.KneeLeft]      .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.KneeRight]     .X = jnts[JointType.KneeRight]     .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.AnkleLeft]     .X = jnts[JointType.AnkleLeft]     .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.AnkleRight]    .X = jnts[JointType.AnkleRight]    .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.FootLeft]      .X = jnts[JointType.FootLeft]      .Position.X;
                            Skeleton.Joints[SkeletonRep.JointType.FootRight]     .X = jnts[JointType.FootRight]     .Position.X;
                            
                            Skeleton.Joints[SkeletonRep.JointType.ShoulderCenter].Y = jnts[JointType.ShoulderCenter].Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.ShoulderLeft]  .Y = jnts[JointType.ShoulderLeft]  .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.ShoulderRight] .Y = jnts[JointType.ShoulderRight] .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.ElbowLeft]     .Y = jnts[JointType.ElbowLeft]     .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.ElbowRight]    .Y = jnts[JointType.ElbowRight]    .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.WristLeft]     .Y = jnts[JointType.WristLeft]     .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.WristRight]    .Y = jnts[JointType.WristRight]    .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.HandLeft]      .Y = jnts[JointType.HandLeft]      .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.HandRight]     .Y = jnts[JointType.HandRight]     .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.Spine]         .Y = jnts[JointType.Spine]         .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.HipCenter]     .Y = jnts[JointType.HipCenter]     .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.HipLeft]       .Y = jnts[JointType.HipLeft]       .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.HipRight]      .Y = jnts[JointType.HipRight]      .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.KneeLeft]      .Y = jnts[JointType.KneeLeft]      .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.KneeRight]     .Y = jnts[JointType.KneeRight]     .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.AnkleLeft]     .Y = jnts[JointType.AnkleLeft]     .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.AnkleRight]    .Y = jnts[JointType.AnkleRight]    .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.FootLeft]      .Y = jnts[JointType.FootLeft]      .Position.Y;
                            Skeleton.Joints[SkeletonRep.JointType.FootRight]     .Y = jnts[JointType.FootRight]     .Position.Y;

                            Skeleton.Joints[SkeletonRep.JointType.ShoulderCenter].Z = jnts[JointType.ShoulderCenter].Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.ShoulderLeft]  .Z = jnts[JointType.ShoulderLeft]  .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.ShoulderRight] .Z = jnts[JointType.ShoulderRight] .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.ElbowLeft]     .Z = jnts[JointType.ElbowLeft]     .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.ElbowRight]    .Z = jnts[JointType.ElbowRight]    .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.WristLeft]     .Z = jnts[JointType.WristLeft]     .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.WristRight]    .Z = jnts[JointType.WristRight]    .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.HandLeft]      .Z = jnts[JointType.HandLeft]      .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.HandRight]     .Z = jnts[JointType.HandRight]     .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.Spine]         .Z = jnts[JointType.Spine]         .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.HipCenter]     .Z = jnts[JointType.HipCenter]     .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.HipLeft]       .Z = jnts[JointType.HipLeft]       .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.HipRight]      .Z = jnts[JointType.HipRight]      .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.KneeLeft]      .Z = jnts[JointType.KneeLeft]      .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.KneeRight]     .Z = jnts[JointType.KneeRight]     .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.AnkleLeft]     .Z = jnts[JointType.AnkleLeft]     .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.AnkleRight]    .Z = jnts[JointType.AnkleRight]    .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.FootLeft]      .Z = jnts[JointType.FootLeft]      .Position.Z;
                            Skeleton.Joints[SkeletonRep.JointType.FootRight]     .Z = jnts[JointType.FootRight]     .Position.Z;
                        }
                    }
                }
            }
            this.Skeleton = Skeleton;
        }

        public override void ModifyModel(SkeletonRep mod)
        {
            SkeletonRep Skeleton = this.Skeleton;
            if(!useNeutralSkeleton)
            {
                mod.Joints[SkeletonRep.JointType.ShoulderCenter] = Skeleton.Joints[SkeletonRep.JointType.ShoulderCenter];
                mod.Joints[SkeletonRep.JointType.ShoulderLeft] = Skeleton.Joints[SkeletonRep.JointType.ShoulderLeft];
                mod.Joints[SkeletonRep.JointType.ShoulderRight] = Skeleton.Joints[SkeletonRep.JointType.ShoulderRight];
                mod.Joints[SkeletonRep.JointType.ElbowLeft] = Skeleton.Joints[SkeletonRep.JointType.ElbowLeft];
                mod.Joints[SkeletonRep.JointType.ElbowRight] = Skeleton.Joints[SkeletonRep.JointType.ElbowRight];
                mod.Joints[SkeletonRep.JointType.WristLeft] = Skeleton.Joints[SkeletonRep.JointType.WristLeft];
                mod.Joints[SkeletonRep.JointType.WristRight] = Skeleton.Joints[SkeletonRep.JointType.WristRight];
                mod.Joints[SkeletonRep.JointType.HandLeft] = Skeleton.Joints[SkeletonRep.JointType.HandLeft];
                mod.Joints[SkeletonRep.JointType.HandRight] = Skeleton.Joints[SkeletonRep.JointType.HandRight];
                mod.Joints[SkeletonRep.JointType.Spine] = Skeleton.Joints[SkeletonRep.JointType.Spine];
                mod.Joints[SkeletonRep.JointType.HipCenter] = Skeleton.Joints[SkeletonRep.JointType.HipCenter];
                mod.Joints[SkeletonRep.JointType.HipLeft] = Skeleton.Joints[SkeletonRep.JointType.HipLeft];
                mod.Joints[SkeletonRep.JointType.HipRight] = Skeleton.Joints[SkeletonRep.JointType.HipRight];
                mod.Joints[SkeletonRep.JointType.KneeLeft] = Skeleton.Joints[SkeletonRep.JointType.KneeLeft];
                mod.Joints[SkeletonRep.JointType.KneeRight] = Skeleton.Joints[SkeletonRep.JointType.KneeRight];
                mod.Joints[SkeletonRep.JointType.AnkleLeft] = Skeleton.Joints[SkeletonRep.JointType.AnkleLeft];
                mod.Joints[SkeletonRep.JointType.AnkleRight] = Skeleton.Joints[SkeletonRep.JointType.AnkleRight];
                mod.Joints[SkeletonRep.JointType.FootLeft] = Skeleton.Joints[SkeletonRep.JointType.FootLeft];
                mod.Joints[SkeletonRep.JointType.FootRight] = Skeleton.Joints[SkeletonRep.JointType.FootRight];
            }
        }
    }
}
