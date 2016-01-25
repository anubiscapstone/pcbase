using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace AnubisClient
{
    public class NamedPipe : CommunicationsInterface
    {
        private NamedPipeServerStream pipe = null;
        private StreamWriter pipeWriter = null;
        private StreamReader pipeReader= null;

        public NamedPipe(NamedPipeServerStream pipe)
        {
            this.pipe = pipe;
            pipeWriter = new StreamWriter(pipe);
            pipeReader = new StreamReader(pipe);
        }

        public bool IsConnected()
        {
            if (pipe == null || !pipe.IsConnected)
                return false;
            return true;
        }

        public override async Task<string> ReadLine()
        {
            if (IsConnected())
                try
                {
                    return await pipeReader.ReadLineAsync();
                }
                catch
                {
                    Close();
                }
            return "";
        }

        public override async void SendLine(string line)
        {
            if (IsConnected())
            {
                try
                {
                    await pipeWriter.WriteLineAsync(line);
                    await pipeWriter.FlushAsync();
                }
                catch
                {
                    Close();
                }
            }
        }

        public override void Close()
        {
            if(IsConnected())
                pipe.Close();
        }
    }
}
