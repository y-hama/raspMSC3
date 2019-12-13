using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public static class Core
    {

        public static string PC_Address { get { return Properties.Settings.Default.PC_Address; } }
        public static string Pi_Address { get { return Properties.Settings.Default.Pi_Address; } }
        public static string LocalHost_Address { get { return Properties.Settings.Default.localhost; } }
        public static int PortA { get { return Properties.Settings.Default.PortA; } }
        public static int PortB { get { return Properties.Settings.Default.PortB; } }
    }
}
