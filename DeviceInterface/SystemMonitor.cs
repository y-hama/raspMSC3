using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DeviceInterface
{
    public class SystemMonitor
    {

        private static SystemMonitor instance = new SystemMonitor();
        public static SystemMonitor Interface { get { return instance; } }
        private SystemMonitor() { }

        private const string tmppath = @"/sys/class/thermal/thermal_zone0/temp";

        public void Initialize()
        {

            Display.Console.WriteLine(DisplayMode.MachineProperty, "MachineName({0})/OS({1})",
                Environment.MachineName.ToString(), Environment.OSVersion.ToString());
            Display.Console.WriteLine(DisplayMode.CurrentDomainProperty, AppDomain.CurrentDomain.FriendlyName.Split('.')[0]);
            new Task(() =>
            {
                string tmpv = string.Empty;
                while (true)
                {
                    try
                    {
#if DEBUG

#else
                        using (FileStream fs = new FileStream(tmppath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var sr = new StreamReader(fs, Encoding.UTF8);
                            {
                                tmpv = sr.ReadLine();
                            }
                        }

                        tmpv = ((double)Convert.ToInt32(tmpv) / 1000).ToString();
#endif
                        Display.Console.WriteLine(DisplayMode.SystemStatus, "cputemp({0}℃)", tmpv);
                    }
                    catch (Exception)
                    {
                        Display.Console.WriteLine(DisplayMode.SystemStatus, "cputemperr({0})", "err");
                    }
                    System.Threading.Thread.Sleep(100);

                }
            }).Start();
        }
    }
}
