using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display
{
    public static class Console
    {
        private static object __bufferlock { get; set; } = new object();

        private static bool Initialized { get; set; } = false;

        private static void Initialize()
        {
            if (!Initialized)
            {
                try
                {
                    System.Console.Clear();
                    foreach (var item in DisplayCore.ItemSet)
                    {
                        System.Console.SetCursorPosition(0, item.Line);
                        System.Console.WriteLine(item.Header + " : " + item.Message);
                    }
                    System.Console.SetCursorPosition(0, 0);
                }
                catch (Exception)
                {

                }
                Initialized = true;
            }
        }

        private static void SetString(DisplaySet item, string msg)
        {
            lock (__bufferlock)
            {
                System.Console.SetCursorPosition(0, item.Line);
                string clearline = string.Empty;
                int nowlen = item.Message == null ? 0 : item.Message.Length;
                for (int i = msg.Length; i < nowlen; i++)
                {
                    clearline += " ";
                }

                item.Message = msg;
                System.Console.SetCursorPosition(0, item.Line);
                System.Console.WriteLine(item.Header + " : " + item.Message + clearline);
                System.Console.SetCursorPosition(0, 0);
            }
        }

        public static void WriteLine(DisplayMode mode, string msg)
        {
            Initialize();
            try
            {
                var idx = DisplayCore.ItemSet.FindIndex(x => x.Mode == mode);
                if (idx >= 0)
                {
                    var item = DisplayCore.ItemSet[idx];
                    SetString(item, msg);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void WriteLine(DisplayMode mode, string format, params object[] arg)
        {
            Initialize();
            try
            {
                var idx = DisplayCore.ItemSet.FindIndex(x => x.Mode == mode);
                if (idx >= 0)
                {
                    var item = DisplayCore.ItemSet[idx];
                    string msg = string.Format(format, arg);
                    SetString(item, msg);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
