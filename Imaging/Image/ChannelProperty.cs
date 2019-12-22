using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Image
{
    [Serializable()]
    public class ChannelProperty
    {

        public int Channels { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Length { get { return Channels * Width * Height; } }

        public string Name { get; set; } = string.Empty;

    }
}
