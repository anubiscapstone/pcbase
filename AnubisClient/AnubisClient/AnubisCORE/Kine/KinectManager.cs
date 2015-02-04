using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;
using AnubisClient.D_Hardware;

namespace AnubisClient.AnubisCORE.Kine
{
    class KinectManager:HardwareInterface
    {
        private List<KinectInterface> KinectSens;
        public KinectManager()
        {
            KinectSens = new List<KinectInterface>();
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
                case 1: break; 
                case 2: break; 
                case 3: break;
                case 4: break;
            }
        }

        public override string getIdentString()
        {
            return "KinectManager";
        }


    }

}
