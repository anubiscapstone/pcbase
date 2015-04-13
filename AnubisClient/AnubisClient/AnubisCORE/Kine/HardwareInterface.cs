using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnubisClient
{
    /// <summary>
    /// Abstract class for defining a hardware interface
    /// </summary>
    public abstract class HardwareInterface
    {
        public abstract string getIdentString();
        public abstract void modifyModel(SkeletonRep mod);
        public abstract bool detectDevice();
        public abstract void startDeviceServer();
        public abstract Form getForm();
        

    }
}
