using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AnubisClient {

    /// <summary>
    /// CommunicationEngine - Loads robot drivers, sends skeleton represntations to all connected robots.
    /// </summary>
	public class NetworkEngine : CommunicationsEngine {
        //port server listens to for incoming connections.
		private int port;

		private BackgroundWorker server;
		private Sock serversock;

        /// <summary>
        /// Must be called to start Comm Engine.
        /// </summary>
		public NetworkEngine(int port) {
            this.port = port;
			server = new BackgroundWorker();
			server.WorkerSupportsCancellation = true;
			server.DoWork += new DoWorkEventHandler(server_acceptConnections);
			// do not need to init serversock here
		}

        /// <summary>
        /// Thread function started by the system, do not call.
        /// listens for incoming connections.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void server_acceptConnections(object sender, DoWorkEventArgs e) {
			while (!server.CancellationPending) {
				Sock newconnection = serversock.accept(); // blocks
                string helo = serversock.readline(); // blocks
				ControlInterface roi = ControlInterface.getNewROIFromHeloString(helo, this, newconnection);
				if (roi == null) continue; // socket was cleaned up for us in the getNewROI.... method
                SignalNewRobot(new GenericEventArgs<ControlInterface>(roi));
			}
			cleanupServer();
		}



        /// <summary>
        /// Called to start server listening.
        /// </summary>
        /// <returns>true if successful</returns>
		public override bool startServer() {
			if (server.IsBusy) return false;


			try {
				serversock = new Sock(port);
				serversock.listen();
				server.RunWorkerAsync();
			}
			catch {
				cleanupServer();
				return false;
			}

			return true;
		}

        /// <summary>
        /// Stop CommEngine from running.
        /// </summary>
        /// <returns>true if successful</returns>
		public override bool stopServer() {
			if (!server.IsBusy) return false;
			server.CancelAsync();
			return true;
		}

        /// <summary>
        /// Close connections to active robots.
        /// Called by startServer in case of failure.
        /// </summary>
		private void cleanupServer() {
			serversock.close();
			serversock = null;
		}
	}
}
