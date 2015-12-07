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

        public event EventHandler<GenericEventArgs<ControlInterface>> newRobotEvent;
        protected void SignalNewRobot(GenericEventArgs<ControlInterface> e)
        {
            EventHandler<GenericEventArgs<ControlInterface>> eventCopy = newRobotEvent;
            if (eventCopy != null) eventCopy(this, e);
        }
    }
}
