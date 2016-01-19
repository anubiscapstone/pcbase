using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    public class NamedPipeEngine : CommunicationsEngine
    {
        private NamedPipe pipe;

        public NamedPipeEngine(string name)
        {
            pipe = new NamedPipe(name);
        }

        public override bool startServer()
        {
            try
            {
                pipe.connect(new AsyncCallback(
                    (IAsyncResult iar) =>
                    {
                        ControlInterface roi = ControlInterface.getNewROIFromHeloString(pipe);
                        if (roi != null)
                            SignalNewRobot(new GenericEventArgs<ControlInterface>(roi));
                    }
                ));
            }
            catch
            {
                cleanupServer();
                return false;
            }
            return true;
        }

        public override bool stopServer()
        {
            try
            {
                pipe.disconnect();
            }
            catch
            {
                cleanupServer();
                return false;
            }
            return true;
        }

        private void cleanupServer()
        {
            pipe.close();
        }
    }
}
