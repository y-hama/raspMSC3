using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raspMSC3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region GetMutex
                string mutexName = "raspMSC3_Device";

                bool createdNew;
                System.Threading.Mutex mutex =
                    new System.Threading.Mutex(true, mutexName, out createdNew);

                if (createdNew == false)
                {
                    mutex.Close();
                    return;
                }

                try
                #endregion
                {

                    Display.Console.WriteLine(DisplayMode.ApplicationStatus, "Device Initialize");
                    #region Device
                    DeviceInterface.SystemMonitor.Interface.Initialize();
                    DeviceInterface.Filter.Interface.Initialize();
                    DeviceInterface.Camera.Interface.Initialize();
                    #endregion

                    #region Communication
                    IF.Instance.CreateCommunication();
                    #endregion
                }
                #region ReleaseMutex
                finally
                {
                    mutex.ReleaseMutex();
                    mutex.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                Display.Console.WriteLine(DisplayMode.ApplicationStatus, "Error {0}.", ex.Message);
                throw;
            }
        }
    }
}
