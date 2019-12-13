using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceInterface.Define
{
    public class _28BYJ_48
    {
        public int coil_A_1_pin { get; private set; }
        public int coil_A_2_pin { get; private set; }
        public int coil_B_1_pin { get; private set; }
        public int coil_B_2_pin { get; private set; }

        private int[][] Seq = new int[][]
        {
            new int[] {1, 0, 0, 1},
            new int[] {1, 0, 0, 0},
            new int[] {1, 1, 0, 0},
            new int[] {0, 1, 0, 0},
            new int[] {0, 1, 1, 0},
            new int[] {0, 0, 1, 0},
            new int[] {0, 0, 1, 1},
            new int[] {0, 0, 0, 1},
        };

        public _28BYJ_48(int a1pin, int a2pin, int b1pin, int b2pin)
        {
            coil_A_1_pin = a1pin;
            coil_A_2_pin = a2pin;
            coil_B_1_pin = b1pin;
            coil_B_2_pin = b2pin;

            DeviceInterface.GPIO.Pins.Open(coil_A_1_pin, GPIO.Direction.Write);
            DeviceInterface.GPIO.Pins.Open(coil_A_2_pin, GPIO.Direction.Write);
            DeviceInterface.GPIO.Pins.Open(coil_B_1_pin, GPIO.Direction.Write);
            DeviceInterface.GPIO.Pins.Open(coil_B_2_pin, GPIO.Direction.Write);
        }

        private void SetStep(int w1, int w2, int w3, int w4)
        {
            DeviceInterface.GPIO.Pins[coil_A_1_pin] = w1 > 0 ? GPIO.Value.High : GPIO.Value.Low;
            DeviceInterface.GPIO.Pins[coil_A_2_pin] = w2 > 0 ? GPIO.Value.High : GPIO.Value.Low;
            DeviceInterface.GPIO.Pins[coil_B_1_pin] = w3 > 0 ? GPIO.Value.High : GPIO.Value.Low;
            DeviceInterface.GPIO.Pins[coil_B_2_pin] = w4 > 0 ? GPIO.Value.High : GPIO.Value.Low;
        }

        public void Rotation(int delay, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                for (int j = 0; j < Seq.Length; j++)
                {
                    SetStep(Seq[j][0], Seq[j][1], Seq[j][2], Seq[j][3]);
                    if (delay > 0) { System.Threading.Thread.Sleep(delay); }
                }
            }
        }

        public void Inverse(int delay, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                for (int j = Seq.Length - 1; j >= 0; j--)
                {
                    SetStep(Seq[j][0], Seq[j][1], Seq[j][2], Seq[j][3]);
                    if (delay > 0) { System.Threading.Thread.Sleep(delay); }
                }
            }
        }
    }
}
