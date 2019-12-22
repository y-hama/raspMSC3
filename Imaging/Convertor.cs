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
            lock (Storage.Instance.__LatestFrameLock)
            {
                if (Storage.Instance.LatestFrame != null)
                {
                    channels = Storage.Instance.LatestFrame.Property.Channels;
                    width = Storage.Instance.LatestFrame.Property.Width;
                    height = Storage.Instance.LatestFrame.Property.Height;
                }
            }

        }

        public static bool GetLatestImage(out System.Drawing.Bitmap bitmap, int width = -1, int height = -1)
        {
            OpenCvSharp.Mat frame = null;
            lock (Storage.Instance.__LatestFrameLock)
            {
                if (Storage.Instance.LatestFrame != null)
                {
                    frame = new OpenCvSharp.Mat(
                        Storage.Instance.LatestFrame.Property.Height,
                        Storage.Instance.LatestFrame.Property.Width,
                        OpenCvSharp.MatType.MakeType(OpenCvSharp.MatType.CV_8U,
                        Storage.Instance.LatestFrame.Property.Channels));

                    Marshal.Copy(Storage.Instance.LatestFrame.Buffer, 0, frame.Data, Storage.Instance.LatestFrame.Buffer.Length);
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
