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
        public static void AddNewControl(object sender, ControlInterface newControl){
            activeControls.Add(newControl);
        }

        /// <summary>
        /// Stops communication to a Control and removes its reference from the list of active Controls
        /// </summary>
        public static void StopControl(int controlIndex)
        {
            if (controlIndex >= activeControls.Count)
                return;
            ControlInterface c = activeControls[controlIndex];
            activeControls.RemoveAt(controlIndex);
            c.StopDevice();
        }

        /// <summary>
        /// Sends a Skeleton to all of the connected Controls
        /// Every new Skeleton will be sent to the Controls via this method.
        /// </summary>
		public static void PublishNewSkeleton(SkeletonRep mod) {
            foreach(var c in activeControls)
                c.UpdateSkeleton(mod);
		}

        public static List<string> GetActiveControls()
        {
            List<string> retval = new List<string>();
            foreach (ControlInterface c in activeControls)
                retval.Add(c.GetHeloString());
            return retval;
        }
	}
}
