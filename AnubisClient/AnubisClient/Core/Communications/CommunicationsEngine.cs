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
        private List<CommunicationsInterface> comms = null;

        public CommunicationsEngine()
        {
            comms = new List<CommunicationsInterface>();
        }

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
                            StopServer();
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

        protected abstract void SetupServer();
        protected abstract void CleanupServer();
        protected abstract Task<CommunicationsInterface> Connect(CancellationToken cancelToken);
        private async void AcceptConnection(CommunicationsInterface comm, CancellationToken cancelToken)
        {
            ControlInterface control = await ControlInterface.getNewROIFromHeloString(comm, cancelToken).ConfigureAwait(false);
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
