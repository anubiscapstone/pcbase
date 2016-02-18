using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace AnubisClient
{
    public abstract class CommunicationsEngine
    {
        private CancellationTokenSource cancel = null;
        private List<CommunicationsInterface> comms = new List<CommunicationsInterface>();

        public async void StartServer()
        {
            if(cancel == null)
            {
                try
                {
                    cancel = new CancellationTokenSource();
                    SetupServer();
                    while (!cancel.Token.IsCancellationRequested)
                    {
                        CommunicationsInterface comm = await Connect(cancel.Token).ConfigureAwait(false);
                        if (comm == null)
                            break;
                        else
                            AcceptConnection(comm, cancel.Token);
                    }
                }
                finally
                {
                    StopServer();
                }
            }
        }
        public void StopServer()
        {
            if (cancel != null)
            {
                cancel.Cancel();
                cancel = null;
                comms.ForEach((CommunicationsInterface c) => { if(c.IsConnected()) c.Close(); });
                comms.Clear();
                CleanupServer();
            }
        }

        /// <summary>
        /// Sets up implementation specific stuff for the server.
        /// </summary>
        protected abstract void SetupServer();

        /// <summary>
        /// Cleans up implementation specific stuff for the server.
        /// </summary>
        protected abstract void CleanupServer();

        /// <summary>
        /// Waits for a new connection on this particular communication method.
        /// If a connection is made, a CommunicationsInterface representing that connection is returned.
        /// If the process is canceled or there is an error, null is returned.
        /// This method is run asnynchronously and supports the await keyword and a CancellationToken.
        /// </summary>
        protected abstract Task<CommunicationsInterface> Connect(CancellationToken cancelToken);

        /// <summary>
        /// Verifies the new connection is from a valid Control and calls the NewControlEvent
        /// </summary>
        private async void AcceptConnection(CommunicationsInterface comm, CancellationToken cancelToken)
        {
            //getNewROIFromHeloString will let the Control modules figure out if this connection is a valid Control.
            //null is returned if it is not.
            ControlInterface control = await ControlInterface.ValidateControl(comm, cancelToken).ConfigureAwait(false);
            if (control != null)
            {
                comms.Add(comm);
                SignalNewControl(control);
            }
        }

        public event EventHandler<ControlInterface> NewControlEvent;
        private void SignalNewControl(ControlInterface control)
        {
            EventHandler<ControlInterface> eventCopy = NewControlEvent;
            if (eventCopy != null) eventCopy(this, control);
        }

    }
}
