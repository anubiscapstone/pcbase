using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace AnubisClient
{
    public abstract class CommunicationsInterface
    {
        protected CancellationToken cancelToken;
        public CommunicationsInterface(CancellationToken cancelToken)
        {
            this.cancelToken = cancelToken;
        }

        public abstract bool IsConnected();
        public abstract Task SendLine(string line);
        public abstract Task<string> ReadLine();
        public abstract void Close();
    }
}
