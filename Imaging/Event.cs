using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Imaging
{
    public class Event
    {
        private static Event instance = new Event();
        public static Event Interface { get { return instance; } }
        private Event() { }

        public double FPS { get { return 1000.0 / elipsedtime; } }
        private double elipsedtime { get; set; } = 1000.0;
        private DateTime stamp { get; set; } = DateTime.Now;
        private void UpdateFPS()
        {
            double rho = Math.Min(1, ((FPS / 50) / 2) + 0.55) - 1E-10;
            elipsedtime = rho * elipsedtime + (1 - rho) * (DateTime.Now - stamp).TotalMilliseconds;
            stamp = DateTime.Now;
        }

        public void ImageRecieved(byte[] data, int channels, int width, int height)
        {
            lock (Storage.Interface.__LatestFrameLock)
            {
                Storage.Interface.LatestFrame = new Image.Layer.Frame()
                { Buffer = data, Channels = channels, Width = width, Height = height };
            }
            UpdateFPS();
        }

        public void CreateNewImageObject()
        {
            Storage.Interface.NewObject();
        }
        public void AddLatestFrame()
        {
            Storage.Interface.AddLatestFrameToObject();
        }
        public void SaveObject(string filename)
        {
            Storage.Interface.SaveObject(filename);
        }


    }
}
