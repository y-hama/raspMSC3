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
        public static System.Drawing.Bitmap BufferToBitmap(byte[] buf, int channels, int width, int height)
        {
            OpenCvSharp.Mat frame = new OpenCvSharp.Mat(height, width, OpenCvSharp.MatType.MakeType(OpenCvSharp.MatType.CV_8U, channels));

            Marshal.Copy(buf, 0, frame.Data, buf.Length);

            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
        }
    }
}
