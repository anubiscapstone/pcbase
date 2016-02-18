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
    /// Encapsulates a two-way, asynchronous, named pipe.
    /// </summary>
    public class NamedPipe : CommunicationsInterface
    {
        private NamedPipeServerStream pipe = null;
        private StreamWriter pipeWriter = null;
        private StreamReader pipeReader= null;

        public NamedPipe(NamedPipeServerStream pipe, CancellationToken cancelToken)
            : base(cancelToken)
        {
            this.pipe = pipe;
            pipeWriter = new StreamWriter(pipe);
            pipeReader = new StreamReader(pipe);
        }

        public override bool IsConnected()
        {
            if (pipe == null || !pipe.IsConnected)
                return false;
            return true;
        }

        public override async Task SendLine(string line)
        {
            if (IsConnected())
            {
                    await pipeWriter.WriteLineAsync(line);
                    await pipeWriter.FlushAsync();
            }
        }

        public override async Task<string> ReadLine()
        {
            if (IsConnected())
                return await pipeReader.ReadLineAsync();
            return "";
        }

        public override void Close()
        {
            if(IsConnected())
                pipe.Close();
        }
    }
}
