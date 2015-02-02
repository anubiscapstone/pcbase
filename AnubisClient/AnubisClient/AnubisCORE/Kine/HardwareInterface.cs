using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    public abstract class HardwareInterface
    {
        public abstract string getIdentString();
        public abstract void modifyModel(SkeletonRep mod);
        public abstract bool detectDevice();
        public abstract bool startDeviceServer();

    }
}
