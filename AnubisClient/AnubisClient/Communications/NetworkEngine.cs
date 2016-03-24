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
    /// <summary>
    /// Encapsulates a TCP/IP server.
    /// As clients connect, it will spawn Sock instances to talk to them.
    /// </summary>
    public class NetworkEngine : CommunicationsEngine
    {
        //using TcpListener for simplicity and the await keyword support
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
            return new Sock(await serversock.AcceptTcpClientAsync().ConfigureAwait(false), cancelToken);
        }

        public override string Identifier()
        {
            return "Network Engine (" + port + ")";
        }
    }
}
