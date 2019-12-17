using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Image
{
    [Serializable()]
    class Layer
    {
        [Serializable()]
        public class Frame
        {
            public byte[] Buffer { get; set; }
            public int Channels { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public string Name { get; set; }
            public Frame Clone()
            {
                return new Frame()
                {
                    Buffer = (byte[])Buffer.Clone(),
                    Channels = Channels,
                    Width = Width,
                    Height = Height,
                };
            }
        }


        public List<Image.Layer.Frame> Frames { get; set; } = new List<Image.Layer.Frame>();
        public void Add(Image.Layer.Frame item)
        {
            Frames.Add(item.Clone());
        }
    }
}
