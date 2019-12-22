using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Runtime.InteropServices;

namespace Imaging.Image
{
    public enum ColorMode
    {
        Gary,
        RGB,
    }
    public class Channels
    {

        public List<Mat> Frames { get; set; } = new List<Mat>();
        private List<ChannelProperty> channelProperty { get; set; } = new List<ChannelProperty>();

        private AdjustProperty property { get; set; }

        public Layer ConvertToLayer()
        {
            Layer layer = new Image.Layer();
            layer.Property = property;
            for (int i = 0; i < Frames.Count; i++)
            {
                var l = new Layer.Frame() { Buffer = new byte[channelProperty[i].Length], Property = channelProperty[i] };
                Marshal.Copy((IntPtr)Frames[i].Data, l.Buffer, 0, l.Buffer.Length);
                layer.Add(l);
            }
            return layer;
        }

        public Channels(Layer layer, ColorMode color = ColorMode.Gary)
        {
            foreach (var item in layer.Frames)
            {
                var frame = new OpenCvSharp.Mat(
                                item.Property.Height, item.Property.Width,
                                OpenCvSharp.MatType.MakeType(OpenCvSharp.MatType.CV_8U,
                                item.Property.Channels));
                Marshal.Copy(item.Buffer, 0, frame.Data, item.Buffer.Length);
                Mat addmat = null;
                switch (color)
                {
                    case ColorMode.Gary:
                        Mat gray = new Mat();
                        OpenCvSharp.Cv2.CvtColor(frame, gray, OpenCvSharp.ColorConversionCodes.BGR2GRAY);
                        OpenCvSharp.Cv2.CvtColor(gray, gray, OpenCvSharp.ColorConversionCodes.GRAY2BGR);
                        addmat = gray;
                        break;
                    case ColorMode.RGB:
                        addmat = frame;
                        break;
                    default:
                        break;
                }
                if (addmat != null)
                {
                    channelProperty.Add(item.Property);
                    Frames.Add(addmat);
                }
            }
            property = layer.Property;
            if (property == null)
            {
                property = new Image.AdjustProperty();
            }
            ApplyProperty();
        }

        private void ApplyProperty()
        {
            if (property.IsAlignment)
            {
                Alignment(property.AlignmentPosX, property.AlignmentPosY, property.AlignmentSize, property.AlignmentTarget);
            }
        }

        public void Rename(int startidx, int stnameidx, List<string> names)
        {
            int tidx = startidx;
            int ntidx = stnameidx;
            for (int i = 0; i < Frames.Count; i++)
            {
                channelProperty[tidx].Name = names[ntidx];
                tidx++;
                ntidx++;
                if (tidx == Frames.Count)
                {
                    tidx = 0;
                }
                if (ntidx == names.Count)
                {
                    ntidx = 0;
                }
            }
        }

        public delegate void ActionCompletedEventHandler();

        public static void ActionTerminate()
        {
            ActionCompletedEvent?.Invoke();
        }
        private static ActionCompletedEventHandler ActionCompletedEvent;
        public static event ActionCompletedEventHandler ActionCompleted
        {
            add { ActionCompletedEvent += value; }
            remove { ActionCompletedEvent -= value; }
        }

        #region Alignment
        private double Gamma(double x, double gm)
        {
            return Math.Pow(x, 1 / gm);
        }
        public void Alignment(int x, int y, int size, byte target)
        {
            property.AlignmentSize = size;
            property.AlignmentPosX = x;
            property.AlignmentPosY = y;
            property.AlignmentTarget = target;

            double t = (double)target / (double)byte.MaxValue;
            List<int> completeList = new List<int>();
            for (int n = 0; n < Frames.Count; n++)
            {
                int nn = n;
                new Task(() =>
                {
                    var item = Frames[nn];
                    double bp = 0, cnt = 0;
                    for (int ii = -size; ii <= size; ii++)
                    {
                        for (int jj = -size; jj <= size; jj++)
                        {
                            if (x + ii >= 0 && x + ii < item.Width && y + jj >= 0 && y + jj < item.Height)
                            {
                                cnt++;
                                var vec = item.Get<Vec3b>(y + jj, x + ii);
                                bp += (vec.Item0 + vec.Item1 + vec.Item2) / 3;
                            }
                        }
                    }
                    bp /= cnt;
                    var r = 1 / (Math.Log(t, ((double)bp / (double)byte.MaxValue)));
                    for (int i = 0; i < item.Width; i++)
                    {
                        for (int j = 0; j < item.Height; j++)
                        {
                            var vecr = item.Get<Vec3b>(j, i);
                            var vec = new OpenCvSharp.Vec3b(
                                (byte)(byte.MaxValue * Math.Min(1, Math.Max(0, Gamma((double)vecr.Item0 / byte.MaxValue, r)))),
                                (byte)(byte.MaxValue * Math.Min(1, Math.Max(0, Gamma((double)vecr.Item1 / byte.MaxValue, r)))),
                                (byte)(byte.MaxValue * Math.Min(1, Math.Max(0, Gamma((double)vecr.Item2 / byte.MaxValue, r)))));
                            item.Set(j, i, vec);
                        }
                    }
                    completeList.Add(nn);
                }).Start();
            }
            while (completeList.Count < Frames.Count) { System.Threading.Thread.Sleep(20); }
            ActionCompletedEvent?.Invoke();
        }
        #endregion

        #region Stretch 
        public void Stretch(byte min, byte max)
        {
            property.StretchMin = min;
            property.StretchMax = max;

            List<int> completeList = new List<int>();
            for (int n = 0; n < Frames.Count; n++)
            {
                int nn = n;
                new Task(() =>
                {
                    var item = Frames[nn];
                    Vec3b vec;
                    for (int i = 0; i < item.Width; i++)
                    {
                        for (int j = 0; j < item.Height; j++)
                        {
                            var vecr = item.Get<Vec3b>(j, i);
                            vec = new OpenCvSharp.Vec3b(
                                (byte)(byte.MaxValue * ((double)(Math.Max(min, Math.Min(max, vecr.Item0)) - min) / (max - min))),
                                (byte)(byte.MaxValue * ((double)(Math.Max(min, Math.Min(max, vecr.Item1)) - min) / (max - min))),
                                (byte)(byte.MaxValue * ((double)(Math.Max(min, Math.Min(max, vecr.Item2)) - min) / (max - min)))
                                );
                            item.Set(j, i, vec);
                        }
                    }
                    completeList.Add(nn);
                }).Start();
            }
            while (completeList.Count < Frames.Count) { System.Threading.Thread.Sleep(20); }
            ActionCompletedEvent?.Invoke();
        }
        #endregion
    }
}
