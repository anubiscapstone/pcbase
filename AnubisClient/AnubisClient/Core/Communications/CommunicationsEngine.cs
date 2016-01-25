using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AnubisClient {

    /// <summary>
    /// CommunicationEngine - Interface for listening for new Controls.
    /// </summary>
    public abstract class CommunicationsEngine
    {
        private bool running = false;

        public async void StartServer()
        {
            if(!running)
            {
                running = true;
                SetupServer();
                while(running)
                {
                    CommunicationsInterface comm = await Connect();
                    if (comm == null)
                        StopServer();
                    else
                        AcceptConnection(comm);
                }
            }
        }
        public void StopServer()
        {
            running = false;
        }

        protected abstract void SetupServer();
        protected abstract Task<CommunicationsInterface> Connect();
        protected async void AcceptConnection(CommunicationsInterface comm)
        {
            ControlInterface control = await ControlInterface.getNewROIFromHeloString(comm);
            if (control != null)
                SignalNewControl(control);
        }

        public event EventHandler<ControlInterface> NewControlEvent;
        private void SignalNewControl(ControlInterface control)
        {
            EventHandler<ControlInterface> eventCopy = NewControlEvent;
            if (eventCopy != null) eventCopy(this, control);
        }

    }
}
