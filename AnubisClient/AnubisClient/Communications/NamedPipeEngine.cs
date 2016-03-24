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
    /// <summary>
    /// Encapsulates the server side of a two-way, asynchronous, named pipe.
    /// As othe pipes connect to it, it will spawn NamedPipe instances to talk to them
    /// </summary>
    public class NamedPipeEngine : CommunicationsEngine
    {
        private NamedPipeServerStream pipe = null;
        private string name;

        public NamedPipeEngine(string name)
        {
            this.name = name;
        }

        //No Setup or Cleanup is needed.  These guys are pretty simple to implement.
        protected override void SetupServer(){}
        protected override void CleanupServer(){}

        protected override async Task<CommunicationsInterface> Connect(CancellationToken cancelToken)
        {
            //Keeps creating server pipes and when a connection is found that server pipe is handed off to the NamedPipe instance to use and a new one is used to find the next connection
            pipe = new NamedPipeServerStream(name, PipeDirection.InOut, System.IO.Pipes.NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            //Wrapping the old async pattern in a TaskFactory so we can use await
            await Task.Factory.FromAsync(pipe.BeginWaitForConnection, pipe.EndWaitForConnection, pipe).ConfigureAwait(false);
            return new NamedPipe(pipe, cancelToken);
        }

        public override string Identifier()
        {
            return "Named Pipe Engine (" + name + ")";
        }
    }
}
