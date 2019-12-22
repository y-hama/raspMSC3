using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace raspMSC3.IF
{
    class Interface : Communication.Server
    {
        protected override void CreateCommandTable()
        {
            AddCommand(Communication.CommandDefine.CreateDefine("appterm", 0, RequestApplicationTerminate));

            AddCommand(Communication.CommandDefine.CreateDefine("reqim", 0, RequestImage));

            AddCommand(Communication.CommandDefine.CreateDefine("camstart", 0, CameraTaskStart));
            AddCommand(Communication.CommandDefine.CreateDefine("camstop", 0, CameraTaskStop));

            AddCommand(Communication.CommandDefine.CreateDefine("filtadjust", 4, FilterAdjust));
            AddCommand(Communication.CommandDefine.CreateDefine("filtnext", 4, FilterNext));
            AddCommand(Communication.CommandDefine.CreateDefine("filtfit", 2, FilterFit));
            AddCommand(Communication.CommandDefine.CreateDefine("filtterm", 0, FilterTerminate));
        }

        private static Communication.Command RequestApplicationTerminate(Communication.Command command)
        {
#if !DEBUG
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "/usr/bin/sudo";
            ps.Arguments = "/sbin/shutdown -h now";
            ps.CreateNoWindow = true;
            ps.UseShellExecute = false;
            Process.Start(ps);
#endif
            return null;
        }

        private static Communication.Command RequestImage(Communication.Command command)
        {
            Communication.Command result = null;
            byte[] framebuffer;
            int ch, w, h;
            bool check = false;
            while (!check)
            {
                try
                {
                    DeviceInterface.Camera.Interface.GetFrameBuffer(out framebuffer, out ch, out w, out h);
                    result = Communication.Command.Create("resim", framebuffer, ch, w, h);
                    check = true;
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        private static Communication.Command CameraTaskStart(Communication.Command command)
        {
            DeviceInterface.Camera.Interface.StreamingInterval = command.ParameterCount > 0 ? Convert.ToInt32(command.Parameter[0]) : 0;
            if (!DeviceInterface.Camera.Interface.Streaming)
            {
                DeviceInterface.Camera.Interface.Streaming = true;
                new Task(() =>
                {
                    while ((!Terminate) && (DeviceInterface.Camera.Interface.Streaming))
                    {
                        try
                        {
                            DateTime stamp = DateTime.Now, temporary;
                            byte[] framebuffer;
                            int ch, w, h;
                            DeviceInterface.Camera.Interface.GetFrameBuffer(out framebuffer, out ch, out w, out h);
                            IF.Instance.Com.Send(Communication.Command.Create("resim", framebuffer, ch, w, h));

                            temporary = DateTime.Now;
                            double sleeptime = DeviceInterface.Camera.Interface.StreamingInterval - (temporary - stamp).TotalMilliseconds;
                            if (sleeptime > 0)
                            {
                                System.Threading.Thread.Sleep((int)sleeptime);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                ).Start();
            }
            return null;
        }

        private static Communication.Command CameraTaskStop(Communication.Command command)
        {
            DeviceInterface.Camera.Interface.Streaming = false;
            return null;
        }

        private static Communication.Command FilterAdjust(Communication.Command command)
        {
            if (DeviceInterface.Filter.Interface.Adjust(
                Convert.ToInt32(command.Parameter[0]),
                Convert.ToInt32(command.Parameter[1]),
                Convert.ToInt32(command.Parameter[2]),
                Convert.ToInt32(command.Parameter[3])))
            {
                DeviceInterface.Filter.Interface.Fit(
                    Convert.ToInt32(command.Parameter[2]),
                    Convert.ToInt32(command.Parameter[3]));
            }
            return null;
        }

        private static Communication.Command FilterNext(Communication.Command command)
        {
            if (DeviceInterface.Filter.Interface.NextFilter(
                    Convert.ToInt32(command.Parameter[0]),
                    Convert.ToInt32(command.Parameter[1]),
                    Convert.ToInt32(command.Parameter[2]),
                    Convert.ToInt32(command.Parameter[3])))
            {
                DeviceInterface.Filter.Interface.Fit(
                    Convert.ToInt32(command.Parameter[2]),
                    Convert.ToInt32(command.Parameter[3]));
            }
            return null;
        }

        private static Communication.Command FilterFit(Communication.Command command)
        {
            DeviceInterface.Filter.Interface.Fit(
                Convert.ToInt32(command.Parameter[0]),
                Convert.ToInt32(command.Parameter[1]));
            return null;
        }

        private static Communication.Command FilterTerminate(Communication.Command command)
        {
            DeviceInterface.Filter.Interface.Terminate();
            return null;
        }
    }
}
