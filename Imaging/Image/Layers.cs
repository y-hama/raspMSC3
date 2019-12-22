using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Image
{
    [Serializable()]
    public class Layer
    {
        [Serializable()]
        public class Frame
        {
            public byte[] Buffer { get; set; }
            public ChannelProperty Property { get; set; } = new ChannelProperty();
            public Frame Clone()
            {
                return new Frame()
                {
                    Buffer = (byte[])Buffer.Clone(),
                    Property = new ChannelProperty()
                    {
                        Channels = Property.Channels,
                        Width = Property.Width,
                        Height = Property.Height,
                        Name = Property.Name,
                    },
                };
            }
        }

        public int FrameCount { get { return Frames.Count; } }

        public AdjustProperty Property { get; set; } = new AdjustProperty();

        public List<Image.Layer.Frame> Frames { get; set; } = new List<Image.Layer.Frame>();
        public void Add(Image.Layer.Frame item)
        {
            Frames.Add(item.Clone());
        }

    }
}
