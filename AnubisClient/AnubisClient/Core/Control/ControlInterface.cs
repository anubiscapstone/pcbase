using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace AnubisClient
{
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
        public static async Task<ControlInterface> ValidateControl(CommunicationsInterface commSock, CancellationToken cancelToken)
        {
            String helo = await commSock.ReadLine();
            if (helo.IndexOf("\n") >= 0)
                helo = helo.Substring(0, helo.IndexOf("\n"));
            Type[] types = Assembly.GetAssembly(typeof(ControlInterface)).GetTypes();
			for (int i = 0; i < types.Length; i++) {
				Type t = types[i];
				if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ControlInterface))) {
                    ControlInterface roi = (ControlInterface)Activator.CreateInstance(t, commSock);
					if (roi.GetHeloString() == helo) return roi;
				}
			}

            await commSock.SendLine("err Your helo string is not recognized.");
            commSock.Close();
			return null;
		}

        /// <summary>
        /// Returns the helo string expected to be sent when this type of Control connects
        /// Implementations simply need to return a unique identifying string for their type of Control
        /// </summary>
        public abstract string GetHeloString();

        /// <summary>
        /// Informs the Control that there is a new frame and new Skeleton.
        /// Implementations can use whichever joints they want, translate this data to fit their purposes, and send it to the actual Control via commSock
        /// </summary>
        public abstract void UpdateSkeleton(SkeletonRep mod);
	}
}
