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
    /// <summary>
    /// Provides a basic algorithm and interface for a communication method.
    /// Users should create an accompaning CommunicationsInterface when implementing a new CommunicationsEngine.
    /// It is best to think of this class of modules as "servers" and the associated CommunicationsInterfaces as the "sockets" that are created between clients.
    /// 
    /// Implementations must define how to setup, cleanup, and wait for/make a connection to a client
    /// Implementations are expected to behave in an asynchronous manner.
    /// 
    /// Once the server is started (StartServer), it will be setup (SetupServer).
    /// It will then begin waiting on a connection (Connect).
    /// If a connection is made, it will be verified as a valid Control and the ControlEngine will be notified.
    /// It will then begin looking for another connection (Connect).
    /// This process can be stopped at any time with StopServer.
    /// Connect implementations are expected to respond to a CancellationToken.
    /// If the server is stopped, it will be cleaned up with CleanupServer after each connection is closed.
    /// </summary>
    public abstract class CommunicationsEngine
    {
        private CancellationTokenSource cancel = null;
        private List<CommunicationsInterface> comms = new List<CommunicationsInterface>();

        /// <summary>
        /// Starts the server if it is not already running.
        /// Asynchronously waits for connections, validates that they are valid Controls, and notifies the ControlEngine
        /// </summary>
        public async void StartServer()
        {
            //cancel will only be set if the server is running
            if(cancel == null)
            {
                try
                {
                    //setup
                    cancel = new CancellationTokenSource();
                    SetupServer();
                    //if the CancellationToken is canceled, we want to stop looking for connections
                    while (!cancel.Token.IsCancellationRequested)
                    {
                        //asynchronously wait for a connection
                        //the await keyword means control will be given back to the calling method until a connection is found
                        CommunicationsInterface comm = await Connect(cancel.Token).ConfigureAwait(false);
                        //if there is a cancellation or error, null is returned and we stop the server
                        if (comm == null)
                            break;
                        else
                            AcceptConnection(comm, cancel.Token);
                    }
                }
                catch (Exception) { }
                finally
                {
                    StopServer();
                }
            }
        }

        /// <summary>
        /// If the server is running, it is stopped.
        /// All connections will be closed.
        /// The server will be cleaned up.
        /// </summary>
        public void StopServer()
        {
            //cancel will only be set if the server is running
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

        /// <summary>
        /// This event is called whenever a valid Control connects via this CommunicationEngine.
        /// A ControlEngine should subscribe to this event to be notified of new Controls.
        /// </summary>
        public event EventHandler<ControlInterface> NewControlEvent;

        /// <summary>
        /// Wrapper method to call the NewControlEvent event.
        /// </summary>
        private void SignalNewControl(ControlInterface control)
        {
            EventHandler<ControlInterface> eventCopy = NewControlEvent;
            if (eventCopy != null) eventCopy(this, control);
        }

        /// <summary>
        /// String to uniquely identify this particular Communication Engine instance
        /// </summary>
        public abstract string Identifier();
    }
}
