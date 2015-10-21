using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;

namespace AnubisClient
{

    /// <summary>
    /// The Kinect Manager is used to facilitate the option of multiple kinects in the system
    /// Responsible for communicating with Kinects
    /// </summary>
    public class KinectManager:HardwareInterface
    {
        private List<KinectInterface> KinectSens;
        private SkeletonRep Kinect_Model;
        private GestureEngine gesture;
        public KinectManager()
        {
            KinectSens = new List<KinectInterface>();
            Kinect_Model = new SkeletonRep();
            gesture = new GestureEngine();
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
                    KinectSens.Add(new KinectInterface(potential));
                }
            }

            if (KinectSens.Count >= 1) 
            {
                return true;
            }
            return false;
            
        }

        /// <summary>
        /// Starts the device server that allows for the communication with the device
        /// </summary>
        public override void startDeviceServer()
        {
            foreach (var Sensor in KinectSens)
            {
                Sensor.startDeviceServer();
            }
        }

        /// <summary>
        /// Updates the skeleton model with the skeleton data from the kinect
        /// </summary>
        /// <param name="mod"></param>
        public override void modifyModel(SkeletonRep mod)
        {

            switch (KinectSens.Count)
            {
                //different models can be used when different numbers of Kinects are present.
                case 1: Kinect_Model = KinectSens[0].ReturnModel();
                    //Left Arm Pitch
                    //From a front view, the elbow and shoulder are compared.  We take their relative angle
                    //to each other to determine the shoulder pitch.
                    double LDX = 0 - (Kinect_Model.ElbowLeft.Pitch - Kinect_Model.ShoulderLeft.Pitch);
                    double LDY = 0 - (Kinect_Model.ElbowLeft.Yaw - Kinect_Model.ShoulderLeft.Yaw);
                    double AngleL = Math.Abs(Math.Atan2(LDY, LDX) * (180 / Math.PI));
                    mod.ShoulderLeft.Pitch = (AngleL);
                    
                    //Left Arm Shoulder Roll
                    //From a side on view, the shoulder and hand are compared.  We take their relative angle
                    //to each other to determine shoulder roll.  
                    double RollLDZ = Kinect_Model.ShoulderLeft.Roll - Kinect_Model.HandLeft.Roll;
                    double RollLDY = Kinect_Model.ShoulderLeft.Yaw - Kinect_Model.HandLeft.Yaw;
                    double RollAngleL = Math.Atan2(RollLDY, RollLDZ) * (180 / Math.PI);
                    mod.ShoulderLeft.Roll = 180 - (RollAngleL + 90);

                    //Right Arm Pitch
                    double RDX = 0 - (Kinect_Model.ElbowRight.Pitch - Kinect_Model.ShoulderRight.Pitch);
                    double RDY = 0 - (Kinect_Model.ElbowRight.Yaw - Kinect_Model.ShoulderRight.Yaw);
                    double AngleR = Math.Abs(Math.Atan2(RDY, RDX) * (180 / Math.PI));
                    mod.ShoulderRight.Pitch = (AngleR);

                    //Right Arm Shoulder Roll
                    double RollRDZ = Kinect_Model.ShoulderRight.Roll - Kinect_Model.HandRight.Roll;
                    double RollRDY = Kinect_Model.ShoulderRight.Yaw - Kinect_Model.HandRight.Yaw;
                    double RollAngleR = Math.Atan2(RollRDY, RollRDZ) * (180 / Math.PI);
                    mod.ShoulderRight.Roll = RollAngleR + 90;
                    
                    
                    break;
                case 2: break; 
                case 3: break;
                case 4: break;
            }

            //run the gesture engine after the Kinematics run, to allow it to override kinematic movements
            //with gestured commands.
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