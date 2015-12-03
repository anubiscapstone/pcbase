using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    public abstract class CommunicationsInterface
    {
        public abstract void sendline(string line);
        public abstract string readline();
        public abstract void close();
    }
}
