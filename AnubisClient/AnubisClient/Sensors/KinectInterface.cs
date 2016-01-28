using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;

namespace AnubisClient
{
    public class KinectInterface:SensorInterface
    {
        private KinectSensor Sensor;
        private SkeletonRep Skeleton;
        private Boolean useNeutralSkeleton = true;
        public KinectInterface()
        {
        }

        public override string getIdentString()
        {
            return "KinectSensor";
        }

        public override void startDeviceServer()
        {
            if (Sensor != null)
            {
                Sensor.SkeletonStream.Enable();
                Sensor.SkeletonFrameReady += this.Sensor_SkeletonFrameReady;


                try
                {
                    Sensor.Start();
                }
                catch (IOException)
                {

                }
            }
        }

        /// <summary>
        /// Disccovers the connected Kinects and adds them to a list of available kinects
        /// </summary>
        /// <returns></returns>
        public override bool detectDevice()
        {
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
        void Sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton = new SkeletonRep();

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

                            Skeleton.ShoulderLeft.X = jnts[JointType.ShoulderLeft].Position.X;
                            Skeleton.ShoulderLeft.Y = jnts[JointType.ShoulderLeft].Position.Y;
                            Skeleton.ShoulderLeft.Z = jnts[JointType.ShoulderLeft].Position.Z;

                            Skeleton.ShoulderRight.X = jnts[JointType.ShoulderRight].Position.X;
                            Skeleton.ShoulderRight.Y = jnts[JointType.ShoulderRight].Position.Y;
                            Skeleton.ShoulderRight.Z = jnts[JointType.ShoulderRight].Position.Z;

                            Skeleton.ElbowLeft.X = jnts[JointType.ElbowLeft].Position.X;
                            Skeleton.ElbowLeft.Y = jnts[JointType.ElbowLeft].Position.Y;
                            Skeleton.ElbowLeft.Z = jnts[JointType.ElbowLeft].Position.Z;

                            Skeleton.ElbowRight.X = jnts[JointType.ElbowRight].Position.X;
                            Skeleton.ElbowRight.Y = jnts[JointType.ElbowRight].Position.Y;
                            Skeleton.ElbowRight.Z = jnts[JointType.ElbowRight].Position.Z;

                            Skeleton.HandLeft.X = jnts[JointType.HandLeft].Position.X;
                            Skeleton.HandLeft.Y = jnts[JointType.HandLeft].Position.Y;
                            Skeleton.HandLeft.Z = jnts[JointType.HandLeft].Position.Z;

                            Skeleton.HandRight.X = jnts[JointType.HandRight].Position.X;
                            Skeleton.HandRight.Y = jnts[JointType.HandRight].Position.Y;
                            Skeleton.HandRight.Z = jnts[JointType.HandRight].Position.Z;

                            Skeleton.AnkleLeft.X = jnts[JointType.AnkleLeft].Position.X;
                            Skeleton.AnkleLeft.Y = jnts[JointType.AnkleLeft].Position.Y;
                            Skeleton.AnkleLeft.Z = jnts[JointType.AnkleLeft].Position.Z;

                            Skeleton.AnkleRight.X = jnts[JointType.AnkleRight].Position.X;
                            Skeleton.AnkleRight.Y = jnts[JointType.AnkleRight].Position.Y;
                            Skeleton.AnkleRight.Z = jnts[JointType.AnkleRight].Position.Z;

                            Skeleton.FootLeft.X = jnts[JointType.FootLeft].Position.X;
                            Skeleton.FootLeft.Y = jnts[JointType.FootLeft].Position.Y;
                            Skeleton.FootLeft.Z = jnts[JointType.FootLeft].Position.Z;

                            Skeleton.FootRight.X = jnts[JointType.FootRight].Position.X;
                            Skeleton.FootRight.Y = jnts[JointType.FootRight].Position.Y;
                            Skeleton.FootRight.Z = jnts[JointType.FootRight].Position.Z;

                            Skeleton.FootRight.X = jnts[JointType.FootRight].Position.X;
                            Skeleton.FootRight.Y = jnts[JointType.FootRight].Position.Y;
                            Skeleton.FootRight.Z = jnts[JointType.FootRight].Position.Z;

                            //Left Arm Pitch
                            //From a front view, the elbow and shoulder are compared.  We take their relative angle
                            //to each other to determine the shoulder pitch.
                            double LDX = 0 - (Skeleton.ElbowLeft.X - Skeleton.ShoulderLeft.X);
                            double LDY = 0 - (Skeleton.ElbowLeft.Y - Skeleton.ShoulderLeft.Y);
                            double AngleL = Math.Abs(Math.Atan2(LDY, LDX) * (180 / Math.PI));
                            Skeleton.ShoulderLeft.Pitch = (AngleL);

                            //Left Arm Shoulder Roll
                            //From a side on view, the shoulder and hand are compared.  We take their relative angle
                            //to each other to determine shoulder roll.  
                            double RollLDZ = Skeleton.ShoulderLeft.Z - Skeleton.HandLeft.Z;
                            double RollLDY = Skeleton.ShoulderLeft.Y - Skeleton.HandLeft.Y;
                            double RollAngleL = Math.Atan2(RollLDY, RollLDZ) * (180 / Math.PI);
                            Skeleton.ShoulderLeft.Roll = 180 - (RollAngleL + 90);

                            //Right Arm Pitch
                            double RDX = 0 - (Skeleton.ElbowRight.Y - Skeleton.ShoulderRight.Y);
                            double RDY = 0 - (Skeleton.ElbowRight.X - Skeleton.ShoulderRight.X);
                            double AngleR = Math.Abs(Math.Atan2(RDY, RDX) * (180 / Math.PI));
                            Skeleton.ShoulderRight.Pitch = (AngleR);

                            //Right Arm Shoulder Roll
                            double RollRDZ = Skeleton.ShoulderRight.Z - Skeleton.HandRight.Z;
                            double RollRDY = Skeleton.ShoulderRight.Y - Skeleton.HandRight.Y;
                            double RollAngleR = Math.Atan2(RollRDY, RollRDZ) * (180 / Math.PI);
                            Skeleton.ShoulderRight.Roll = RollAngleR + 90;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Updates the skeleton model with the skeleton data from the kinect
        /// </summary>
        /// <param name="mod"></param>
        public override void modifyModel(SkeletonRep mod)
        {
            if(!useNeutralSkeleton)
            {
                mod.ShoulderLeft.X = Skeleton.ShoulderLeft.X;
                mod.ShoulderLeft.Y = Skeleton.ShoulderLeft.Y;
                mod.ShoulderLeft.Z = Skeleton.ShoulderLeft.Z;

                mod.ShoulderRight.X = Skeleton.ShoulderRight.X;
                mod.ShoulderRight.Y = Skeleton.ShoulderRight.Y;
                mod.ShoulderRight.Z = Skeleton.ShoulderRight.Z;

                mod.ElbowLeft.X = Skeleton.ElbowLeft.X;
                mod.ElbowLeft.Y = Skeleton.ElbowLeft.Y;
                mod.ElbowLeft.Z = Skeleton.ElbowLeft.Z;

                mod.ElbowRight.X = Skeleton.ElbowRight.X;
                mod.ElbowRight.Y = Skeleton.ElbowRight.Y;
                mod.ElbowRight.Z = Skeleton.ElbowRight.Z;

                mod.HandLeft.X = Skeleton.HandLeft.X;
                mod.HandLeft.Y = Skeleton.HandLeft.Y;
                mod.HandLeft.Z = Skeleton.HandLeft.Z;

                mod.HandRight.X = Skeleton.HandRight.X;
                mod.HandRight.Y = Skeleton.HandRight.Y;
                mod.HandRight.Z = Skeleton.HandRight.Z;

                mod.AnkleLeft.X = Skeleton.AnkleLeft.X;
                mod.AnkleLeft.Y = Skeleton.AnkleLeft.Y;
                mod.AnkleLeft.Z = Skeleton.AnkleLeft.Z;

                mod.AnkleRight.X = Skeleton.AnkleRight.X;
                mod.AnkleRight.Y = Skeleton.AnkleRight.Y;
                mod.AnkleRight.Z = Skeleton.AnkleRight.Z;

                mod.FootLeft.X = Skeleton.FootLeft.X;
                mod.FootLeft.Y = Skeleton.FootLeft.Y;
                mod.FootLeft.Z = Skeleton.FootLeft.Z;

                mod.FootRight.X = Skeleton.FootRight.X;
                mod.FootRight.Y = Skeleton.FootRight.Y;
                mod.FootRight.Z = Skeleton.FootRight.Z;

                mod.FootRight.X = Skeleton.FootRight.X;
                mod.FootRight.Y = Skeleton.FootRight.Y;
                mod.FootRight.Z = Skeleton.FootRight.Z;

                mod.ShoulderLeft.Pitch = Skeleton.ShoulderLeft.Pitch;
                mod.ShoulderLeft.Roll = Skeleton.ShoulderLeft.Roll;
                mod.ShoulderRight.Pitch = Skeleton.ShoulderRight.Pitch;
                mod.ShoulderRight.Roll = Skeleton.ShoulderRight.Roll;
            }
        }

        public override System.Windows.Forms.Form getForm()
        {
            return new Kinect_Form(this);
        }

    }

}
