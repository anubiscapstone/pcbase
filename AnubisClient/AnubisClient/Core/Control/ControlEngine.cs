using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AnubisClient {

    /// <summary>
    /// ControlEngine - Loads robot drivers, sends skeleton represntations to all connected robots.
    /// </summary>
	public static class ControlEngine
    {
        private static List<ControlInterface> activeControls = new List<ControlInterface>();

        /// <summary>
        /// Must be called to start Robo Engine.
        /// </summary>
        public static void AddNewRobot(object sender, ControlInterface newControl){
            activeControls.Add(newControl);
        }

        /// <summary>
        /// Called by Kinematics Engine to update Robo Engine.
        /// Sends a skeletal representation of the user.
        /// </summary>
		public static void PublishNewSkeleton(SkeletonRep mod) {
            foreach(var c in activeControls)
                c.UpdateSkeleton(mod);
		}

	}
}
