using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raspMSC3.IF
{
    class Instance
    {
        public static Interface Com
        {
            get; set;
        }

        public static void CreateCommunication()
        {
            string srcaddr, distaddr;
#if DEBUG
            srcaddr = Communication.Core.LocalHost_Address;
            distaddr = Communication.Core.LocalHost_Address;
#else
            srcaddr = Communication.Core.Pi_Address;
            distaddr = Communication.Core.PC_Address;
#endif
            Display.Console.WriteLine(DisplayMode.ApplicationStatus, "Device Initialized");

            while (true)
            {
                try
                {
                    Com = new IF.Interface();
                    Com.DataRecieved += Com_DataRecieved;
                    Com.Initialize(srcaddr, distaddr, Communication.Core.PortA, Communication.Core.PortB, false);
                }
                catch (Exception)
                {

                }
            }
        }

        private static void Com_DataRecieved(Communication.Command cmd)
        {
            Display.Console.WriteLine(DisplayMode.CommunicationLatestRecievedMessage, "rec -> {0}", cmd.GetString());
        }
    }
}
