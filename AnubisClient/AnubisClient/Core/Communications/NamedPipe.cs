using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;

namespace AnubisClient
{
    public class NamedPipe : CommunicationsInterface
    {
        private string name;
        private bool connected;
        private NamedPipeServerStream pipe;
        private StreamWriter streamWriter;

        public NamedPipe(string name)
        {
            this.name = name;
            connected = false;
            pipe = new NamedPipeServerStream(name, PipeDirection.InOut, 1, PipeTransmissionMode.Message);
            streamWriter = new StreamWriter(pipe);
        }

        public void connect(AsyncCallback callback)
        {
            try
            {
                pipe.BeginWaitForConnection(new AsyncCallback(
                    (IAsyncResult iar) =>
                    {
                        try
                        {
                            pipe.EndWaitForConnection(iar);
                            callback(iar);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    
                ), pipe);
            }
            catch
            {
                throw;
            }
        }

        public void disconnect()
        {
            try
            {
                connected = false;
                pipe.Disconnect();
            }
            catch
            {
                throw;
            }
        }

        public override void close()
        {
            connected = false;
            pipe.Close();
        }

        public override string readline()
        {
            string ret = "";
            if(connected)
            {
                do
                {
                    int c = pipe.ReadByte();
                    if (c >= 0)
                        ret += Convert.ToChar(c);
                }
                while (!pipe.IsMessageComplete);
            }
            return ret;
        }

        public override void sendline(string line)
        {
            if(connected)
            {
                streamWriter.Write(line);
                streamWriter.Flush();
            }
        }
    }
}
