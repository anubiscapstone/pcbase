using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;
using AnubisClient.AnubisCORE.Gesture;

namespace AnubisClient.D_Hardware
{
    public class KinectInterface:HardwareInterface
    {
        private GestureEngine Gesture;
        private KinectSensor Sensor;
        private SkeletonRep Skeleton;
        public KinectInterface()
        {
            Skeleton = new SkeletonRep();
            Gesture = new GestureEngine();
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
                    foreach (Skeleton s in skeletons)
                    {

                        if (s.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            JointCollection jnts = s.Joints;

                            Skeleton.ShoulderLeft.Pitch = jnts[JointType.ShoulderLeft].Position.X;
                            Skeleton.ShoulderLeft.Yaw = jnts[JointType.ShoulderLeft].Position.Y;
                            Skeleton.ShoulderLeft.Roll = jnts[JointType.ShoulderLeft].Position.Z;

                            Skeleton.ShoulderRight.Pitch = jnts[JointType.ShoulderRight].Position.X;
                            Skeleton.ShoulderRight.Yaw = jnts[JointType.ShoulderRight].Position.Y;
                            Skeleton.ShoulderRight.Roll = jnts[JointType.ShoulderRight].Position.Z;

                            Skeleton.ElbowLeft.Pitch = jnts[JointType.ElbowLeft].Position.X;
                            Skeleton.ElbowLeft.Yaw = jnts[JointType.ElbowLeft].Position.Y;
                            Skeleton.ElbowLeft.Roll = jnts[JointType.ElbowLeft].Position.Z;

                            Skeleton.ElbowRight.Pitch = jnts[JointType.ElbowRight].Position.X;
                            Skeleton.ElbowRight.Yaw = jnts[JointType.ElbowRight].Position.Y;
                            Skeleton.ElbowRight.Roll = jnts[JointType.ElbowRight].Position.Z;

                            Skeleton.HandLeft.Pitch = jnts[JointType.HandLeft].Position.X;
                            Skeleton.HandLeft.Yaw = jnts[JointType.HandLeft].Position.Y;
                            Skeleton.HandLeft.Roll = jnts[JointType.HandLeft].Position.Z;

                            Skeleton.HandRight.Pitch = jnts[JointType.HandRight].Position.X;
                            Skeleton.HandRight.Yaw = jnts[JointType.HandRight].Position.Y;
                            Skeleton.HandRight.Roll = jnts[JointType.HandRight].Position.Z;

                            Skeleton.AnkleLeft.Pitch = jnts[JointType.AnkleLeft].Position.X;
                            Skeleton.AnkleLeft.Yaw = jnts[JointType.AnkleLeft].Position.Y;
                            Skeleton.AnkleLeft.Roll = jnts[JointType.AnkleLeft].Position.Z;

                            Skeleton.AnkleRight.Pitch = jnts[JointType.AnkleRight].Position.X;
                            Skeleton.AnkleRight.Yaw = jnts[JointType.AnkleRight].Position.Y;
                            Skeleton.AnkleRight.Roll = jnts[JointType.AnkleRight].Position.Z;

                            Skeleton.FootLeft.Pitch = jnts[JointType.FootLeft].Position.X;
                            Skeleton.FootLeft.Yaw = jnts[JointType.FootLeft].Position.Y;
                            Skeleton.FootLeft.Roll = jnts[JointType.FootLeft].Position.Z;

                            Skeleton.FootRight.Pitch = jnts[JointType.FootRight].Position.X;
                            Skeleton.FootRight.Yaw = jnts[JointType.FootRight].Position.Y;
                            Skeleton.FootRight.Roll = jnts[JointType.FootRight].Position.Z;

                            Skeleton.FootRight.Pitch = jnts[JointType.FootRight].Position.X;
                            Skeleton.FootRight.Yaw = jnts[JointType.FootRight].Position.Y;
                            Skeleton.FootRight.Roll = jnts[JointType.FootRight].Position.Z;
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

            //Left Arm Pitch
            //From a front view, the elbow and shoulder are compared.  We take their relative angle
            //to each other to determine the shoulder pitch.
            double LDX = 0 - (Skeleton.ElbowLeft.Pitch - Skeleton.ShoulderLeft.Pitch);
            double LDY = 0 - (Skeleton.ElbowLeft.Yaw - Skeleton.ShoulderLeft.Yaw);
            double AngleL = Math.Abs(Math.Atan2(LDY, LDX) * (180 / Math.PI));
            mod.ShoulderLeft.Pitch = (AngleL);

            //Left Arm Shoulder Roll
            //From a side on view, the shoulder and hand are compared.  We take their relative angle
            //to each other to determine shoulder roll.  
            double RollLDZ = Skeleton.ShoulderLeft.Roll - Skeleton.HandLeft.Roll;
            double RollLDY = Skeleton.ShoulderLeft.Yaw - Skeleton.HandLeft.Yaw;
            double RollAngleL = Math.Atan2(RollLDY, RollLDZ) * (180 / Math.PI);
            mod.ShoulderLeft.Roll = 180 - (RollAngleL + 90);

            //Right Arm Pitch
            double RDX = 0 - (Skeleton.ElbowRight.Pitch - Skeleton.ShoulderRight.Pitch);
            double RDY = 0 - (Skeleton.ElbowRight.Yaw - Skeleton.ShoulderRight.Yaw);
            double AngleR = Math.Abs(Math.Atan2(RDY, RDX) * (180 / Math.PI));
            mod.ShoulderRight.Pitch = (AngleR);

            //Right Arm Shoulder Roll
            double RollRDZ = Skeleton.ShoulderRight.Roll - Skeleton.HandRight.Roll;
            double RollRDY = Skeleton.ShoulderRight.Yaw - Skeleton.HandRight.Yaw;
            double RollAngleR = Math.Atan2(RollRDY, RollRDZ) * (180 / Math.PI);
            mod.ShoulderRight.Roll = RollAngleR + 90;


            //run the gesture engine after the Kinematics run, to allow it to override kinematic movements
            //with gestured commands.
            Gesture.newFrame(mod, Skeleton);
        }

        public override System.Windows.Forms.Form getForm()
        {
            return new Kinect_Form(this);
        }

    }

}
