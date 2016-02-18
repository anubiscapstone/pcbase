using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AnubisClient {

    /// <summary>
    /// Module that manages the ControlInterfaces.
    /// Keeps references to all of the Controls and can be asked to update them all with a new Skeleton
    /// </summary>
	public static class ControlEngine
    {
        private static List<ControlInterface> activeControls = new List<ControlInterface>();

        /// <summary>
        /// Event handler for CommunicationEngine's NewControlEvent
        /// This will be called whenever a new Control is connected to the system and validated
        /// </summary>
        public static void AddNewRobot(object sender, ControlInterface newControl){
            activeControls.Add(newControl);
        }

        /// <summary>
        /// Sends a Skeleton to all of the connected Controls
        /// Every new Skeleton will be sent to the Controls via this method.
        /// </summary>
		public static void PublishNewSkeleton(SkeletonRep mod) {
            foreach(var c in activeControls)
                c.UpdateSkeleton(mod);
		}
	}
}
