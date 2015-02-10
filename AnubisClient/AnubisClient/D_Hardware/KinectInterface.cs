using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;

namespace AnubisClient.D_Hardware
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

                            float LDX = jnts[JointType.ElbowLeft].Position.X - jnts[JointType.ShoulderLeft].Position.X;
                            float LDY = jnts[JointType.ElbowLeft].Position.Y - jnts[JointType.ShoulderLeft].Position.Y;
                            double LAP = Math.Atan(LDY / LDX) * (180 / Math.PI);
                            SR.ShoulderLeft.Pitch = LAP;

                            float RLDZ = jnts[JointType.ElbowLeft].Position.Z - jnts[JointType.ShoulderLeft].Position.Z;
                            float RLDY = jnts[JointType.ElbowLeft].Position.Y - jnts[JointType.ShoulderLeft].Position.Y;
                            double RLAP = (Math.Atan(RLDY / RLDZ)) * (180 / Math.PI);
                            SR.ShoulderLeft.Roll = (90 - RLAP) + 90;

                            float RDX = jnts[JointType.ElbowRight].Position.X - jnts[JointType.ShoulderRight].Position.X;
                            float RDY = jnts[JointType.ElbowRight].Position.Y - jnts[JointType.ShoulderRight].Position.Y;
                            double RAP = Math.Atan(RDY / RDX) * (180 / Math.PI) + 180;
                            SR.ShoulderLeft.Pitch = RAP;

                            float RRDZ = jnts[JointType.ElbowRight].Position.Z - jnts[JointType.ShoulderRight].Position.Z;
                            float RRDY = jnts[JointType.ElbowRight].Position.Y - jnts[JointType.ShoulderRight].Position.Y;
                            double RRAP = Math.Atan(RRDY / RRDZ) * (180 / Math.PI);
                            SR.ShoulderLeft.Roll = RRAP;
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
