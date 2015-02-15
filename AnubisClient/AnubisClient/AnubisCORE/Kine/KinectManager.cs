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
        private SkeletonRep Mod;
        public KinectManager()
        {
            KinectSens = new List<KinectInterface>();
            Mod = new SkeletonRep();
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
                case 1: Mod = KinectSens[0].ReturnModel(); 
                    double LDX = Mod.ElbowLeft.Pitch - Mod.ShoulderLeft.Pitch;
                    double LDY = Mod.ElbowLeft.Yaw - Mod.ShoulderLeft.Yaw;
                    double AngleL = Math.Atan2(LDY, LDX) * (180 / Math.PI);
                    mod.ShoulderLeft.Pitch = 180-AngleL;
                    
                    //Left Arm Shoulder Roll
                    double RollLDZ = Mod.ShoulderLeft.Roll - Mod.HandLeft.Roll;
                    double RollLDY = Mod.ShoulderLeft.Yaw - Mod.HandLeft.Yaw;
                    double RollAngleL = Math.Atan2(RollLDY, RollLDZ) * (180 / Math.PI);
                    mod.ShoulderLeft.Roll =180-((90 - RollAngleL) + 90);

                    //Right Arm Pitch
                    double RDX = Mod.ElbowRight.Pitch - Mod.ShoulderRight.Pitch;
                    double RDY = Mod.ElbowRight.Yaw - Mod.ShoulderRight.Yaw;
                    double AngleR = Math.Atan2(RDY, RDX) * (180 / Math.PI) + 180;
                    mod.ShoulderRight.Pitch = 180-(AngleR);

                    //Right Arm Shoulder Roll
                    double RollRDZ = Mod.ShoulderRight.Roll - Mod.HandRight.Roll;
                    double RollRDY = Mod.ShoulderRight.Yaw - Mod.HandRight.Yaw;
                    double RollAngleR = Math.Atan2(RollRDY, RollRDZ) * (180 / Math.PI);
                    mod.ShoulderRight.Roll =180-(RollAngleR);
                    
                    break;
                case 2: break; 
                case 3: break;
                case 4: break;
            }
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
