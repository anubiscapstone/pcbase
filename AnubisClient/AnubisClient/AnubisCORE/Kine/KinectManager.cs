using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;
using AnubisClient.D_Hardware;

namespace AnubisClient.AnubisCORE.Kine
{
    public class KinectManager:HardwareInterface
    {
        private List<KinectInterface> KinectSens;
        private SkeletonRep Kinect_Model;
        private Gesture.GestureEngine gesture;
        public KinectManager()
        {
            KinectSens = new List<KinectInterface>();
            Kinect_Model = new SkeletonRep();
            gesture = new Gesture.GestureEngine();
        }

        public override bool detectDevice()
        {
            foreach (var potential in KinectSensor.KinectSensors)
            {
                if (potential.Status == KinectStatus.Connected)
                {
                    KinectSens.Add(new KinectInterface(potential));
                }
            }

            if (KinectSens.Count >= 1) 
            {
                return true;
            }
            return false;
            
        }

        public override void startDeviceServer()
        {
            foreach (var Sensor in KinectSens)
            {
                Sensor.startDeviceServer();
            }
        }

        public override void modifyModel(SkeletonRep mod)
        {

            switch (KinectSens.Count)
            {
                case 1: Kinect_Model = KinectSens[0].ReturnModel();
                    //Right Arm Pitch
                    double LDX = Kinect_Model.ElbowLeft.Pitch - Kinect_Model.ShoulderLeft.Pitch;
                    double LDY = Kinect_Model.ElbowLeft.Yaw - Kinect_Model.ShoulderLeft.Yaw;
                    double AngleL = Math.Atan2(LDY, LDX) * (180 / Math.PI);
                    mod.ShoulderLeft.Pitch = (0 - AngleL);
                    
                    //Left Arm Shoulder Roll
                    double RollLDZ = Kinect_Model.ShoulderLeft.Roll - Kinect_Model.HandLeft.Roll;
                    double RollLDY = Kinect_Model.ShoulderLeft.Yaw - Kinect_Model.HandLeft.Yaw;
                    double RollAngleL = Math.Atan2(RollLDY, RollLDZ) * (180 / Math.PI);
                    mod.ShoulderLeft.Roll =180-((90 - RollAngleL) + 90);

                    //Right Arm Pitch
                    double RDX = Kinect_Model.ElbowRight.Pitch - Kinect_Model.ShoulderRight.Pitch;
                    double RDY = Kinect_Model.ElbowRight.Yaw - Kinect_Model.ShoulderRight.Yaw;
                    double AngleR = Math.Atan2(RDY, RDX) * (180 / Math.PI) + 180;
                    mod.ShoulderRight.Pitch = 180-(AngleR);

                    //Right Arm Shoulder Roll
                    double RollRDZ = Kinect_Model.ShoulderRight.Roll - Kinect_Model.HandRight.Roll;
                    double RollRDY = Kinect_Model.ShoulderRight.Yaw - Kinect_Model.HandRight.Yaw;
                    double RollAngleR = Math.Atan2(RollRDY, RollRDZ) * (180 / Math.PI);
                    mod.ShoulderRight.Roll =180-(RollAngleR);
                    
                    break;
                case 2: break; 
                case 3: break;
                case 4: break;
            }

            gesture.newFrame(mod, Kinect_Model);
        }

        public override string getIdentString()
        {
            return "KinectManager";
        }

        public override System.Windows.Forms.Form getForm()
        {
            return new Kinect_Form(this);
        }


    }

}
