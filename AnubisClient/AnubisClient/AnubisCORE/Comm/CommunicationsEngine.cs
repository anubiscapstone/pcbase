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
	public static class CommunicationsEngine {
        //port server listens to for incoming connections.
		public const int SERVER_PORT = 1337;

		private static BackgroundWorker server;
		private static Sock serversock;
        //list of connected robots.
		private static List<RobotInterface> activeRobots;

        /// <summary>
        /// Must be called to start Comm Engine.
        /// </summary>
		public static void initialize() {
			server = new BackgroundWorker();
			server.WorkerSupportsCancellation = true;
			server.DoWork += new DoWorkEventHandler(server_acceptConnections);
			activeRobots = new List<RobotInterface>();
			// do not need to init serversock here
		}

        /// <summary>
        /// Thread function started by the system, do not call.
        /// listens for incoming connections.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private static void server_acceptConnections(object sender, DoWorkEventArgs e) {
			while (!server.CancellationPending) {
				Sock newconnection = serversock.accept(); // blocks
				RobotInterface roi = RobotInterface.getNewROIFromHeloString(newconnection);
				if (roi == null) continue; // socket was cleaned up for us in the getNewROI.... method
				activeRobots.Add(roi);
			}
			cleanupServer();
		}

        /// <summary>
        /// Called by Kinematics Engine to update Comm Engine.
        /// Sends a skeletal representation of the user.
        /// </summary>
        /// <param name="mod">Skeleton representation of user.</param>
		public static void publishNewSkeleton(SkeletonRep mod) {
			for (int i = 0; i < activeRobots.Count; i++) {
				activeRobots[i].updateSkeleton(mod);
			}
		}

        /// <summary>
        /// Gets the list of connecting robots from a connection string.
        /// </summary>
        /// <param name="helostring"></param>
        /// <returns></returns>
		public static RobotInterface[] getROIsFromHeloString(string helostring) {
			List<RobotInterface> lst = new List<RobotInterface>();

			for (int i = 0; i < activeRobots.Count; i++) {
				RobotInterface roi = activeRobots[i];
				if (roi.getHeloString() == helostring) lst.Add(roi);
			}

			return lst.ToArray();
		}

        /// <summary>
        /// Called to start server listening.
        /// </summary>
        /// <returns>true if successful</returns>
		public static bool startServer() {
			if (server.IsBusy) return false;


			try {
				serversock = new Sock(SERVER_PORT);
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
		public static bool stopServer() {
			if (!server.IsBusy) return false;
			server.CancelAsync();
			return true;
		}

        /// <summary>
        /// Close connections to active robots.
        /// Called by startServer in case of failure.
        /// </summary>
		private static void cleanupServer() {
			while (activeRobots.Count > 0) {
				activeRobots[0].sock_close();
				activeRobots.RemoveAt(0);
			}
			serversock.close();
			serversock = null;
		}
	}
}
