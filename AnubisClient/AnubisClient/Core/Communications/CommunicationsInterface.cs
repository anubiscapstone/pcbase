using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace AnubisClient
{
    /// <summary>
    /// Provides an interface to communicate with a client over a specific communication method.
    /// Users should create an accompaning CommunicationsEngine when implementing a new CommunicationsInterface.
    /// It is best to think of this class of modules as "sockets" and the associated CommunicationsEngine as the "server" that connects to the client and creates these.
    /// 
    /// Implementations must report if the connection is closed, how to close a connection, and how to read and write lines to the client
    /// Implementations are expected to behave in an asynchronous manner.
    /// The parent CommunicationEngine's CancellationToken is available as cancelToken.
    /// SendLine and ReadLine are expected to respond to it.
    /// </summary>
    public abstract class CommunicationsInterface
    {
        protected CancellationToken cancelToken;
        public CommunicationsInterface(CancellationToken cancelToken)
        {
            this.cancelToken = cancelToken;
        }

        /// <summary>
        /// Returns true if the connection is open and the client can be communicated with.
        /// Returns false otherwise.
        /// </summary>
        public abstract bool IsConnected();

        /// <summary>
        /// Sends a line of plain text ending with a new line to the client.
        /// This method runs asynchronously and supports the await keyword.
        /// It can be cancelled if the parent CommunicationsEngine is stopped.
        /// </summary>
        public abstract Task SendLine(string line);

        /// <summary>
        /// Reads a line of plain text ending with a carriage return from the client.
        /// This method runs asynchronously and supports the await keyword.
        /// It can be cancelled if the parent CommunicationsEngine is stopped.
        /// </summary>
        public abstract Task<string> ReadLine();

        /// <summary>
        /// Closes the connection with the client and cleans up.
        /// </summary>
        public abstract void Close();
    }
}
