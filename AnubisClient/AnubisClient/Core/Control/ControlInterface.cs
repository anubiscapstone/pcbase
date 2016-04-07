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
    /// Provides an interface to alert Controls of new Skeletons and translate skeletal data in the context of the Control
    /// This interface will be instantiated with a generic interface to communicate to the actual Control, but the method of communication does not need to be known.
    /// </summary>
	public abstract class ControlInterface {
        /// <summary>
        /// Generic interface to communicate to the actual Control.
        /// </summary>
        protected CommunicationsInterface commSock;

        /// <summary>
        /// Create a new ControlInterface with some method of communicating the the actual Control
        /// </summary>
        public ControlInterface(CommunicationsInterface commSock)
        {
            this.commSock = commSock;
        }

        /// <summary>
        /// Stop communication to this Control
        /// </summary>
        public void StopDevice()
        {
            commSock.Close();
        }

        /// <summary>
        /// Verify a connecting control is a valid control, instantiate an interface, and return it
        /// This method can be run asynchronously with the await keyword and it will not block while communicating to the potential Control.
        /// </summary>
        public static async Task<ControlInterface> ValidateControl(CommunicationsInterface commSock, CancellationToken cancelToken)
        {
            //Wait for the potential Control to send a helo string
            String helo = await commSock.ReadLine();

            //Strip the newline character for string comparison
            if (helo.IndexOf("\n") >= 0)
                helo = helo.Substring(0, helo.IndexOf("\n"));
            
            //For each supported type of Control, check the helo string until we find a match
            foreach (Type t in Assembly.GetAssembly(typeof(ControlInterface)).GetTypes())
            {
                if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ControlInterface))) {
                    ControlInterface roi = (ControlInterface)Activator.CreateInstance(t, commSock);
					if (roi.GetHeloString() == helo) return roi;
				}
			}
            
            //We couldnt validate the Control.  Inform the failed connector and close the connection.
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
