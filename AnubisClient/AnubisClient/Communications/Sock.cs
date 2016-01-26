using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace AnubisClient {
	public class Sock : CommunicationsInterface{
        private int port;
        private TcpClient sock = null;
        private NetworkStream stream = null;

        public Sock(TcpClient sock, int port, CancellationToken cancelToken)
            : base(cancelToken)
        {
            this.port = port;
            this.sock = sock;
            this.stream = sock.GetStream();
		}

        public override bool IsConnected()
        {
            if (sock == null || !sock.Connected)
                return false;
            return true;
        }

        public override async Task SendLine(string line)
        {
            if(IsConnected())
            {
                line += "\n";
                byte[] buf = Encoding.ASCII.GetBytes(line);
                await stream.WriteAsync(buf, 0, line.Length, cancelToken).ConfigureAwait(false);
            }
		}

        public override async Task<string> ReadLine()
        {
            string message = "";
            if (IsConnected())
            {
                do
                {
                    if (cancelToken.IsCancellationRequested)
                        break;
                    byte[] buf = new byte[4096];
                    int amountRead = await stream.ReadAsync(buf, 0, buf.Length, cancelToken).ConfigureAwait(false);
                    if (amountRead != 0)
                        message += Encoding.ASCII.GetString(buf, 0, amountRead);
                }
                while (message.IndexOf("\n") < 0);
            }
            return message;
		}

        public override void Close()
        {
            if (IsConnected())
                sock.Close();
		}
    }
}
