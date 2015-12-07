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
	public abstract class ControlInterface {
        protected CommunicationsInterface commSock;

        /// <summary>
        /// Create a new robot interface with a socket
        /// </summary>
        /// <param name="robotsock">socket robot is connected on</param>
        public ControlInterface(CommunicationsInterface commSock)
        {
            this.commSock = commSock;
        }

        /// <summary>
        /// Clever function that, when called, will get the concrete class for the connecting robot.
        /// This ensures easy installation of new robot drivers.
        /// </summary>
        /// <param name="sock">Connecting robot socket</param>
        /// <returns>Concrete robot interface</returns>
        public static ControlInterface getNewROIFromHeloString(CommunicationsInterface commSock)
        {
            String helo = commSock.readline(); // blocks

            Type[] types = Assembly.GetAssembly(typeof(ControlInterface)).GetTypes();
			for (int i = 0; i < types.Length; i++) {
				Type t = types[i];
				if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ControlInterface))) {
                    ControlInterface roi = (ControlInterface)Activator.CreateInstance(t, commSock);
					if (roi.getHeloString() == helo) return roi;
				}
			}

            commSock.sendline("err Your helo string is not recognized.");
            commSock.close();
			return null;
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
