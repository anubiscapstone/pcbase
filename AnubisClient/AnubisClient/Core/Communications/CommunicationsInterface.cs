using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AnubisClient
{
    public abstract class CommunicationsInterface
    {
        public abstract void SendLine(string line);
        public abstract Task<string> ReadLine();
        public abstract void Close();
    }
}
