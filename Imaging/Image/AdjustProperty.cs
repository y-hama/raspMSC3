using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging.Image
{
    [Serializable()]
    public class AdjustProperty
    {
        public bool IsAlignment { get; set; } = false;
        public byte AlignmentTarget { get; set; } = 100;
        public int AlignmentSize { get; set; } = 0;
        public int AlignmentPosX { get; set; } = 0;
        public int AlignmentPosY { get; set; } = 0;

        public byte StretchMin { get; set; } = 0;
        public byte StretchMax { get; set; } = 255;
    }
}
