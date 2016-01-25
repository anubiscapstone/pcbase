using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace AnubisClient
{
    public class NamedPipeEngine : CommunicationsEngine
    {
        private string name;

        public NamedPipeEngine(string name)
        {
            this.name = name;
        }

        protected override void SetupServer() {}

        protected override async Task<CommunicationsInterface> Connect()
        {
            try
            {
                NamedPipeServerStream pipe = new NamedPipeServerStream(name, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
                await Task.Factory.FromAsync(pipe.BeginWaitForConnection, pipe.EndWaitForConnection, pipe);
                return new NamedPipe(pipe);
            }
            catch
            {
                return null;
            }
        }
    }
}
