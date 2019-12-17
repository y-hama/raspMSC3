using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Imaging
{
    public static class Convertor
    {
        public static void GetLatestImageSize(out int channels, out int width, out int height)
        {
            channels = width = height = 0;
            lock (Storage.Interface.__LatestFrameLock)
            {
                if (Storage.Interface.LatestFrame != null)
                {
                    channels = Storage.Interface.LatestFrame.Channels;
                    width = Storage.Interface.LatestFrame.Width;
                    height = Storage.Interface.LatestFrame.Height;
                }
            }

        }

        public static bool GetLatestImage(out System.Drawing.Bitmap bitmap, int width = -1, int height = -1)
        {
            OpenCvSharp.Mat frame = null;
            lock (Storage.Interface.__LatestFrameLock)
            {
                if (Storage.Interface.LatestFrame != null)
                {
                    frame = new OpenCvSharp.Mat(
                        Storage.Interface.LatestFrame.Height,
                        Storage.Interface.LatestFrame.Width,
                        OpenCvSharp.MatType.MakeType(OpenCvSharp.MatType.CV_8U,
                        Storage.Interface.LatestFrame.Channels));

                    Marshal.Copy(Storage.Interface.LatestFrame.Buffer, 0, frame.Data, Storage.Interface.LatestFrame.Buffer.Length);
                }
            }
            bool ret = false;
            if (frame == null)
            {
                bitmap = null;
            }
            else
            {
                if (width > 0 && height > 0)
                {
                    if (frame.Width != width || frame.Height != height)
                    {
                        frame = frame.Resize(new OpenCvSharp.Size(width, height));
                    }
                }
                bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                ret = true;
            }
            return ret;
        }
    }
}
