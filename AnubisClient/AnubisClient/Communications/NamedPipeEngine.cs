using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace AnubisClient
{
    public class NamedPipeEngine : CommunicationsEngine
    {
        private NamedPipeServerStream pipe = null;
        private string name;

        public NamedPipeEngine(string name)
        {
            this.name = name;
        }

        protected override void SetupServer(){}
        protected override void CleanupServer(){}

        protected override async Task<CommunicationsInterface> Connect(CancellationToken cancelToken)
        {
            pipe = new NamedPipeServerStream(name, PipeDirection.InOut, System.IO.Pipes.NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            await Task.Factory.FromAsync(pipe.BeginWaitForConnection, pipe.EndWaitForConnection, pipe).ConfigureAwait(false);
            return new NamedPipe(pipe, cancelToken);
        }
    }
}
