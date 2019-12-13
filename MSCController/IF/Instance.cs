using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCController.IF
{
    class Instance
    {
        public static Interface Com { get; set; }

        private static System.Diagnostics.Process debugprocess { get; set; }

        public static void CreateCommunication()
        {
#if DEBUG 
            debugprocess = System.Diagnostics.Process.Start("..\\..\\..\\raspMSC3\\bin\\Debug\\raspMSC3.exe");
#endif
            string srcaddr, distaddr;
#if DEBUG
            srcaddr = Communication.Core.LocalHost_Address;
            distaddr = Communication.Core.LocalHost_Address;
#else
            srcaddr = Communication.Core.PC_Address;
            distaddr = Communication.Core.Pi_Address; 
#endif
            Com = new IF.Interface();
            Com.Initialize(srcaddr, distaddr, Communication.Core.PortB, Communication.Core.PortA);
#if DEBUG
            while (!Com.IsConnected) { System.Threading.Thread.Sleep(100); }
#endif
        }

        public static void KillDebugProcess()
        {
#if DEBUG
            try { debugprocess.Kill(); } catch (Exception) { }
#endif
        }
    }
}
