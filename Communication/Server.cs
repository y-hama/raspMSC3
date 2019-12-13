using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Communication
{
    public abstract class Server : Wrapper
    {

        protected override TaskFunction Function
        {
            get
            {
                return ServerFunction;
            }
        }

        private void ServerFunction()
        {
            while (!Terminate)
            {
#if DEBUG
                new Task(() =>
                {
                    System.Threading.Thread.Sleep(10000);
                    if (!IsConnected)
                    {
                        Environment.Exit(0);
                    }
                }).Start();
#endif
                listener = new TcpListener(sourceIPAddress, recPort);
                listener.Start();
                Display.Console.WriteLine(DisplayMode.CommunicationState, "Server ListenStart({0}:{1}).",
                    ((IPEndPoint)listener.LocalEndpoint).Address,
                    ((IPEndPoint)listener.LocalEndpoint).Port);

                client = listener.AcceptTcpClient();
                Display.Console.WriteLine(DisplayMode.CommunicationState, "Connect to Client({0}:{1}).",
                    ((IPEndPoint)client.Client.RemoteEndPoint).Address,
                    ((IPEndPoint)client.Client.RemoteEndPoint).Port);

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
