using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceInterface
{
    public class Motor
    {
        public enum Direction
        {
            Forward,
            Backward,
        }

        private static Motor instance = new Motor();
        public static Motor Interface { get { return instance; } }
        private Motor() { }

        private List<Define._28BYJ_48> mList { get; set; }

        public void Initialize()
        {
            mList = new List<Define._28BYJ_48>();
        }

        public void Export(int a1pin, int a2pin, int b1pin, int b2pin)
        {
            if (GPIO.Pins.IsOpened(a1pin) ||
                GPIO.Pins.IsOpened(a2pin) ||
                GPIO.Pins.IsOpened(b1pin) ||
                GPIO.Pins.IsOpened(b2pin))
            {
                return;
            }
            mList.Add(new Define._28BYJ_48(a1pin, a2pin, b1pin, b2pin));
        }

        public void Test(int rot)
        {
            Rotation(Direction.Forward, rot, 10);
        }

        public void Rotation(Direction dir, int steps, int delay = 10, int id = 0)
        {
            if (mList.Count > id)
            {
                var motor = mList[id];
                switch (dir)
                {
                    case Direction.Forward:
                        motor.Rotation(delay, steps);
                        break;
                    case Direction.Backward:
                        motor.Inverse(delay, steps);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
