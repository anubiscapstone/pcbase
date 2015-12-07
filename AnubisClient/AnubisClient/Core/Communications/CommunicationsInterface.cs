using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AnubisClient
{
    public abstract class CommunicationsInterface
    {
        public abstract void sendline(string line);
        public abstract string readline();
        public abstract void close();

        /// <summary>
        /// Used to return a response to a robot query.
        /// </summary>
        /// <param name="message">string message</param>
        /// <param name="callback">Event called when the robot responds</param>
        public void solicitResponse(string message, EventHandler<GenericEventArgs<string>> callback)
        {
            BackgroundWorker transactor = new BackgroundWorker();
            transactor.DoWork += (object sender, DoWorkEventArgs e) => {
                string response = readline(); // blocks
                callback(this, new GenericEventArgs<string>(response));
            };
            sendline(message);
            transactor.RunWorkerAsync();
        }
    }
}
