using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging
{
    public class Store
    {
        private static Store instance = new Store();
        public static Store Instance { get { return instance; } }
        private Store() { }


        public int SpectrumCount { get { if (SpectrumImage != null) { return SpectrumImage.FrameCount; } else { return -1; } } }
        private Image.Layer SpectrumImage { get; set; } = null;
        public Image.ChannelProperty GetProperty(int index)
        {
            if (SpectrumImage == null) { return null; }
            return SpectrumImage.Frames[index].Property;
        }
        public System.Drawing.Bitmap GetBitmap(int index)
        {
            if (Spectrum == null) { return null; }
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(Spectrum.Frames[index]);
        }

        private Image.Channels Spectrum { get; set; } = null;
        public System.Drawing.Color GetColor(int index, int x, int y)
        {
            OpenCvSharp.Vec3b vec = Spectrum.Frames[index].Get<OpenCvSharp.Vec3b>(y, x);
            return System.Drawing.Color.FromArgb(vec.Item2, vec.Item1, vec.Item0);
        }
        public byte GetBrightness(int index, int x, int y)
        {
            var c = GetColor(index, x, y);
            return (byte)((c.R + c.G + c.B) / 3);
        }

        public bool Save(string name)
        {
            if (Spectrum == null) { return false; }
            Storage.Instance.Save(Spectrum.ConvertToLayer(), name);
            return true;
        }

        public List<string> GetImageNames()
        {
            return Storage.Instance.GetImageNames();
        }

        public void SetSelectedImage(string name, Image.ColorMode color)
        {
            SpectrumImage = Storage.Instance.LoadObject(name);
            Spectrum = new Image.Channels(SpectrumImage, color);
        }

        public bool Remane(int startidx, int stnameidx, List<string> names)
        {
            if (Spectrum == null) { return false; }
            Spectrum.Rename(startidx, stnameidx, names);
            return true;
        }

        public void Alignment(int x, int y, int size, byte target)
        {
            if (Spectrum == null) { Imaging.Image.Channels.ActionTerminate(); return; }
            Spectrum.Alignment(x, y, size, target);
        }

        public void Stretch(byte min, byte max)
        {
            if (Spectrum == null) { Imaging.Image.Channels.ActionTerminate(); return; }
            Spectrum.Stretch(min, max);
        }
    }
}
