using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Communication
{
    public abstract class Client : Wrapper
    {
        protected override TaskFunction Function
        {
            get
            {
                return CLientFunction;
            }
        }

        private void CLientFunction()
        {
            while (!Terminate)
            {
                bool retry = true;
                while (retry)
                {
                    try
                    {

                        client = new TcpClient(distinationIPAddress.ToString(), sendPort);
                        Display.Console.WriteLine(DisplayMode.CommunicationState, "Connect To Server({0}:{1}) , ({2}:{3})。",
                            ((IPEndPoint)client.Client.RemoteEndPoint).Address,
                            ((IPEndPoint)client.Client.RemoteEndPoint).Port,
                            ((IPEndPoint)client.Client.LocalEndPoint).Address,
                            ((IPEndPoint)client.Client.LocalEndPoint).Port);
                        retry = false;
                    }
                    catch (Exception)
                    {
                        retry = true;
                    }
                }

                ConnectedProcess();
                while (!Terminate)
                {
                    if (!RecieveProcess())
                    {
                        Display.Console.WriteLine(DisplayMode.CommunicationError, "Disconnected.");
                        break;
                    }
                }
                Close();
            }
        }
    }
}
