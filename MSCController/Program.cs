using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCController
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                #region GetMutex
                string mutexName = "raspMSC3_Controller";

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
                    #region Communication
                    IF.Instance.CreateCommunication();
                    IF.Instance.Com.ImageRecieved += Imaging.Event.Interface.ImageRecieved;
                    #endregion

                    #region GC
                    new Task(() => { while (true) { GC.Collect(); System.Threading.Thread.Sleep(250); } }).Start();
                    #endregion

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Forms.MainForm());

#if DEBUG
                    IF.Instance.KillDebugProcess();
#endif
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
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
