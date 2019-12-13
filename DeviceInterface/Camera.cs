using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Runtime.InteropServices;

namespace DeviceInterface
{
    public class Camera
    {

        private static Camera instance = new Camera();
        public static Camera Interface { get { return instance; } }
        private Camera() { }

        public bool Streaming { get; set; } = false;

        private VideoCapture capture { get; set; }

        private DateTime timestamp { get; set; } = DateTime.Now;
        private double elipsedtime { get; set; }

        private object __latestframelock = new object();
        private Mat latestFrame { get; set; } = new Mat();

        private void CameraTask()
        {
            while (true)
            {
                try
                {
                    lock (__latestframelock)
                    {
                        capture.Read(latestFrame);
                    }
                    System.Threading.Thread.Sleep(10);
                }
                catch (Exception)
                {
                }
            }
        }

        public void Initialize()
        {
            capture = new VideoCapture(0);
            if (!capture.IsOpened()) { throw new Exception(); }

            //capture.FrameWidth = 1280;
            //capture.FrameHeight = 720;
            new Task(CameraTask).Start();
            Display.Console.WriteLine(DisplayMode.DeviceCameraState, "Camera Available.");
        }

        public void GetFrame(out Mat frame)
        {
            bool check = false;
            frame = new Mat();
            while (!check)
            {
                try
                {
                    lock (__latestframelock)
                    {
                        frame = latestFrame.Clone();
                    }
                    check = true;
                }
                catch (Exception)
                {
                }
            }
        }

        public void GetFrameBuffer(out byte[] buf, out int channels, out int width, out int height)
        {
            try
            {
                Mat mat;
                GetFrame(out mat);
                channels = mat.Channels();
                width = mat.Width;
                height = mat.Height;
                buf = new byte[(int)(mat.Total() * mat.Channels())];
                Marshal.Copy(mat.Data, buf, 0, buf.Length);

                double rho = 0.9;
                double etm = (DateTime.Now - timestamp).TotalMilliseconds;
                elipsedtime = rho * elipsedtime + (1 - rho) * etm;
                timestamp = DateTime.Now;
                Display.Console.WriteLine(DisplayMode.DeviceCameraState,
                    "c({0}),w({1}),h({2}) -> {3,5}fps", channels, width, height, Math.Round(1000.0 / elipsedtime, 2));

            }
            catch (Exception)
            {
                Display.Console.WriteLine(DisplayMode.DeviceCameraState, "frame cannot captured.");
                throw;
            }
        }

        public void GetSideLuminosity(int width, out double top, out double bottom, out double left, out double right)
        {
            Mat frame;
            GetFrame(out frame);
            if (frame.Channels() > 1)
            {
                Cv2.CvtColor(frame, frame, ColorConversionCodes.BGR2GRAY);
            }
            top = bottom = left = right = 0;
            for (int i = 0; i < frame.Width; i++)
            {
                top += frame.Get<byte>(0, i);
                bottom += frame.Get<byte>(frame.Height - 1, i);
            }
            for (int j = 0; j < frame.Height; j++)
            {
                left += frame.Get<byte>(j, 0);
                right += frame.Get<byte>(j, frame.Width - 1);
            }
            top /= frame.Width;
            bottom /= frame.Width;
            left /= frame.Height;
            right /= frame.Height;
        }
    }
}
