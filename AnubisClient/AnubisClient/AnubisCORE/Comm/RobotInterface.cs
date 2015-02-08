using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace AnubisClient {
    /// <summary>
    /// Encapsulates a robot as it appears to the server.
    /// </summary>
	public abstract class RobotInterface {
		private Sock robotsock;

        /// <summary>
        /// Create a new robot interface with a socket
        /// </summary>
        /// <param name="robotsock">socket robot is connected on</param>
		public RobotInterface(Sock robotsock) {
			this.robotsock = robotsock;
		}

        /// <summary>
        /// Clever function that, when called, will get the concrete class for the connecting robot.
        /// This ensures easy installation of new robot drivers.
        /// </summary>
        /// <param name="sock">Connecting robot socket</param>
        /// <returns>Concrete robot interface</returns>
		public static RobotInterface getNewROIFromHeloString(Sock sock) {
			string helo = sock.readline(); // blocks

			Type[] types = Assembly.GetAssembly(typeof(RobotInterface)).GetTypes();
			for (int i = 0; i < types.Length; i++) {
				Type t = types[i];
				if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(RobotInterface))) {
					RobotInterface roi = (RobotInterface)Activator.CreateInstance(t, sock);
					if (roi.getHeloString() == helo) return roi;
				}
			}

			sock.sendline("err Your helo string is not recognized.");
			sock.close();
			return null;
		}

        /// <summary>
        /// Send a string to the robot.
        /// </summary>
        /// <param name="line">string command to send</param>
		protected void sock_sendline_sync(string line) {
			robotsock.sendline(line);
		}

        /// <summary>
        /// Used to return a response to a robot query.
        /// </summary>
        /// <param name="message">string message</param>
        /// <param name="callback">Event called when the robot responds</param>
		protected void sock_invokeProto_solicitRobotResponse_async(string message, EventHandler<GenericEventArgs<string>> callback) {
			BackgroundWorker transactor = new BackgroundWorker();
			transactor.DoWork += (object sender, DoWorkEventArgs e) => {
				string response = robotsock.readline(); // blocks
				callback(this, new GenericEventArgs<string>(response));
			};
			sock_sendline_sync(message);
			transactor.RunWorkerAsync();
		}

		public void sock_close() {
			robotsock.close();
		}

		public abstract string getHeloString();
		public abstract void updateSkeleton(SkeletonRep mod);
		public abstract void useNeutralSkeleton();
		public abstract void useNullSkeleton();
		public abstract void verifyRobot(EventHandler<GenericEventArgs<bool>> callback);
		public abstract void requestData(string identifier, EventHandler<GenericEventArgs<string>> callback);
		public abstract void ping(EventHandler<GenericEventArgs<long>> callback);
	}
}
