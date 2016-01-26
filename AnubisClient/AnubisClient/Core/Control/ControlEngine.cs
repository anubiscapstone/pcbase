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
	public static class ControlEngine{

        //list of connected robots.
		private static List<ControlInterface> activeControls;

        /// <summary>
        /// Must be called to start Robo Engine.
        /// </summary>
		public static void initialize() {
			activeControls = new List<ControlInterface>();
		}

        public static void addNewRobot(object sender, ControlInterface e){
            activeControls.Add(e);
        }

        /// <summary>
        /// Called by Kinematics Engine to update Robo Engine.
        /// Sends a skeletal representation of the user.
        /// </summary>
        /// <param name="mod">Skeleton representation of user.</param>
		public static void publishNewSkeleton(SkeletonRep mod) {
            foreach(var c in activeControls)
                c.updateSkeleton(mod);
		}

	}
}
