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
        private CommunicationsEngine commDriver;
        private CommunicationsInterface commSock;

        /// <summary>
        /// Create a new robot interface with a socket
        /// </summary>
        /// <param name="robotsock">socket robot is connected on</param>
        public RobotInterface(CommunicationsEngine commDriver, CommunicationsInterface commSock)
        {
            this.commDriver = commDriver;
            this.commSock = commSock;
        }

        /// <summary>
        /// Clever function that, when called, will get the concrete class for the connecting robot.
        /// This ensures easy installation of new robot drivers.
        /// </summary>
        /// <param name="sock">Connecting robot socket</param>
        /// <returns>Concrete robot interface</returns>
        public static RobotInterface getNewROIFromHeloString(String helo, CommunicationsEngine commDriver, CommunicationsInterface commSock)
        {
			Type[] types = Assembly.GetAssembly(typeof(RobotInterface)).GetTypes();
			for (int i = 0; i < types.Length; i++) {
				Type t = types[i];
				if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(RobotInterface))) {
                    RobotInterface roi = (RobotInterface)Activator.CreateInstance(t, commDriver, commSock);
					if (roi.getHeloString() == helo) return roi;
				}
			}

            commSock.sendline("err Your helo string is not recognized.");
            commSock.close();
			return null;
		}

        /// <summary>
        /// Send a string to the robot.
        /// </summary>
        /// <param name="line">string command to send</param>
		protected void sock_sendline_sync(string line) {
            commSock.sendline(line);
		}

        /// <summary>
        /// Used to return a response to a robot query.
        /// </summary>
        /// <param name="message">string message</param>
        /// <param name="callback">Event called when the robot responds</param>
		protected void sock_invokeProto_solicitRobotResponse_async(string message, EventHandler<GenericEventArgs<string>> callback) {
			BackgroundWorker transactor = new BackgroundWorker();
			transactor.DoWork += (object sender, DoWorkEventArgs e) => {
                string response = commSock.readline(); // blocks
				callback(this, new GenericEventArgs<string>(response));
			};
			sock_sendline_sync(message);
			transactor.RunWorkerAsync();
		}

		public void sock_close() {
            commSock.close();
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
