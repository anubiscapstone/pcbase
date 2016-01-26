using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace AnubisClient
{
	public class NetworkEngine : CommunicationsEngine
    {
        private TcpListener serversock = null;
        private int port;

		public NetworkEngine(int port)
        {
            this.port = port;
		}

        protected override void SetupServer()
        {
            serversock = new TcpListener(IPAddress.Any, port);
            serversock.Start();
        }
        protected override void CleanupServer()
        {
            serversock.Stop();
        }

        protected override async Task<CommunicationsInterface> Connect(CancellationToken cancelToken)
        {
            return new Sock(await serversock.AcceptTcpClientAsync().ConfigureAwait(false), port, cancelToken);
        }
    }
}
