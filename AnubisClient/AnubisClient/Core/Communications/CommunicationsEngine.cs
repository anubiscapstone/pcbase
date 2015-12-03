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
    public abstract class CommunicationsEngine
    {
        /// <summary>
        /// Must be called to start Comm Engine.
        /// </summary>
        public abstract bool startServer();
        public abstract bool stopServer();

        public event EventHandler<GenericEventArgs<RobotInterface>> newRobotEvent;
        protected void SignalNewRobot(GenericEventArgs<RobotInterface> e)
        {
            EventHandler<GenericEventArgs<RobotInterface>> eventCopy = newRobotEvent;
            if (eventCopy != null) eventCopy(this, e);
        }
    }
}
