using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;

namespace AnubisClient
{
    class KinectInterface
    {
        KinectSensor Sense;
        SkeletonRep SR;
        int tracked_skel;
        public KinectInterface(KinectSensor sensor)
        {
            Sense = sensor;
            SR = new SkeletonRep();
        }

        public  string getIdentString()
        {
            return "KinectSensor";
        }

        public  void startDeviceServer()
        {
            if (Sense != null)
            {
                Sense.SkeletonStream.Enable();
                Sense.SkeletonFrameReady += this.Sense_SkeletonFrameReady;
                

                try
                {
                    Sense.Start();
                }
                catch (IOException)
                {

                }
            }
        }

        void Sense_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    //Copy Skeleton data to placeholder
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }

                //Update joint position information
                if (skeletons.Length != 0)
                {
                    tracked_skel = 0;
                    foreach (Skeleton s in skeletons)
                    {

                        if (s.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            tracked_skel++;
                            JointCollection jnts = s.Joints;

                            SR.ShoulderLeft.Pitch = jnts[JointType.ShoulderLeft].Position.X;
                            SR.ShoulderLeft.Yaw = jnts[JointType.ShoulderLeft].Position.Y;
                            SR.ShoulderLeft.Roll = jnts[JointType.ShoulderLeft].Position.Z;

                            SR.ShoulderRight.Pitch = jnts[JointType.ShoulderRight].Position.X;
                            SR.ShoulderRight.Yaw = jnts[JointType.ShoulderRight].Position.Y;
                            SR.ShoulderRight.Roll = jnts[JointType.ShoulderRight].Position.Z;

                            SR.ElbowLeft.Pitch = jnts[JointType.ElbowLeft].Position.X;
                            SR.ElbowLeft.Yaw = jnts[JointType.ElbowLeft].Position.Y;
                            SR.ElbowLeft.Roll = jnts[JointType.ElbowLeft].Position.Z;

                            SR.ElbowRight.Pitch = jnts[JointType.ElbowRight].Position.X;
                            SR.ElbowRight.Yaw = jnts[JointType.ElbowRight].Position.Y;
                            SR.ElbowRight.Roll = jnts[JointType.ElbowRight].Position.Z;

                            SR.HandLeft.Pitch = jnts[JointType.HandLeft].Position.X;
                            SR.HandLeft.Yaw = jnts[JointType.HandLeft].Position.Y;
                            SR.HandLeft.Roll = jnts[JointType.HandLeft].Position.Z;

                            SR.HandRight.Pitch = jnts[JointType.HandRight].Position.X;
                            SR.HandRight.Yaw = jnts[JointType.HandRight].Position.Y;
                            SR.HandRight.Roll = jnts[JointType.HandRight].Position.Z;

                            SR.AnkleLeft.Pitch = jnts[JointType.AnkleLeft].Position.X;
                            SR.AnkleLeft.Yaw = jnts[JointType.AnkleLeft].Position.Y;
                            SR.AnkleLeft.Roll = jnts[JointType.AnkleLeft].Position.Z;

                            SR.AnkleRight.Pitch = jnts[JointType.AnkleRight].Position.X;
                            SR.AnkleRight.Yaw = jnts[JointType.AnkleRight].Position.Y;
                            SR.AnkleRight.Roll = jnts[JointType.AnkleRight].Position.Z;

                            SR.FootLeft.Pitch = jnts[JointType.FootLeft].Position.X;
                            SR.FootLeft.Yaw = jnts[JointType.FootLeft].Position.Y;
                            SR.FootLeft.Roll = jnts[JointType.FootLeft].Position.Z;

                            SR.FootRight.Pitch = jnts[JointType.FootRight].Position.X;
                            SR.FootRight.Yaw = jnts[JointType.FootRight].Position.Y;
                            SR.FootRight.Roll = jnts[JointType.FootRight].Position.Z;

                            SR.FootRight.Pitch = jnts[JointType.FootRight].Position.X;
                            SR.FootRight.Yaw = jnts[JointType.FootRight].Position.Y;
                            SR.FootRight.Roll = jnts[JointType.FootRight].Position.Z;
                        }
                    }
                }
            }
        }

        public  SkeletonRep ReturnModel()
        {
            return SR;
        }


    }
}
