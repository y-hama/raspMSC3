using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceInterface
{
    public class Filter
    {

        private static Filter instance = new Filter();
        public static Filter Interface { get { return instance; } }
        private Filter() { }

        private bool Working { get; set; } = false;
        private bool ForceTerminate { get; set; } = false;

        public void Initialize()
        {
            GPIO.Pins.Initialize();
            Motor.Interface.Initialize();
            Motor.Interface.Export(6, 13, 19, 26);
            Display.Console.WriteLine(DisplayMode.DeviceFilterState, "Filter Available.");
        }

        #region I/F
        public bool NextFilter(int direction, int step, int limit, int area)
        {
            if (Working) { return true; }
            Working = true;
            Display.Console.WriteLine(DisplayMode.DeviceFilterState, "Filter Next Start.");
            FitFilterProcess(true, direction, step, limit, area, 1000);

            double top, bottom, left, right;
            Camera.Interface.GetSideLuminosity(area, area, out top, out bottom, out left, out right);
            Display.Console.WriteLine(DisplayMode.DeviceFilterState, "Filter Next Completed. limit{0,3}, left{1,3}, right{2,3}", limit, (int)left, (int)right);
            Working = false;
            if (ForceTerminate)
            {
                ForceTerminate = false;
                return false;
            }
            return true;
        }

        public bool Adjust(int direction, int step, int limit, int area)
        {
            if (Working) { return true; }
            Working = true;
            Display.Console.WriteLine(DisplayMode.DeviceFilterState, "Filter Adjust Start.");
            AdjustProcess(direction, step, limit, area);

            double top, bottom, left, right;
            Camera.Interface.GetSideLuminosity(area, area, out top, out bottom, out left, out right);
            Display.Console.WriteLine(DisplayMode.DeviceFilterState, "Filter Next Completed. limit{0,3}, left{1,3}, right{2,3}", limit, (int)left, (int)right);
            Working = false;
            if (ForceTerminate)
            {
                ForceTerminate = false;
                return false;
            }
            return true;
        }

        public bool Fit(int limit, int area)
        {
            if (Working) { return true; }
            Working = true;
            Display.Console.WriteLine(DisplayMode.DeviceFilterState, "Filter Fit Start.");
            FitFilterProcess(false, 1, 0, limit, area, 100);

            double top, bottom, left, right;
            Camera.Interface.GetSideLuminosity(area, area, out top, out bottom, out left, out right);
            Display.Console.WriteLine(DisplayMode.DeviceFilterState, "Filter Next Completed. limit{0,3}, left{1,3}, right{2,3}", limit, (int)left, (int)right);
            Working = false;
            if (ForceTerminate)
            {
                ForceTerminate = false;
                return false;
            }
            return true;
        }

        public void Terminate()
        {
            if (Working)
            {
                ForceTerminate = true;
                while (Working) { }
                Display.Console.WriteLine(DisplayMode.DeviceFilterState, "Filter Process ForceTerminate.");
            }
        }
        #endregion

        #region Process

        private void FitFilterProcess(bool next, int direction, int step, int limit, int area, int wait)
        {
            if (direction == 0) { return; }
            Motor.Direction dir = direction > 0 ? Motor.Direction.Backward : direction < 0 ? Motor.Direction.Forward : 0;
            if (next) { Motor.Interface.Rotation(dir, step, 1); }

            System.Threading.Thread.Sleep(wait);
            bool complete = false;
            while (!complete && !ForceTerminate)
            {
                double top, bottom, left, right;
                Camera.Interface.GetSideLuminosity(area, area, out top, out bottom, out left, out right);
                Display.Console.WriteLine(DisplayMode.DeviceFilterState, "fitfseq := limit{0,3}, left{1,3}, right{2,3}", limit, (int)left, (int)right);
                if (left < limit || right < limit)
                {
                    Motor.Direction exdir = Motor.Direction.Backward;
                    if (left < limit && right < limit)
                    {
                        exdir = dir;
                    }
                    else if (left < limit)
                    {
                        exdir = Motor.Direction.Backward;
                    }
                    else if (right < limit)
                    {
                        exdir = Motor.Direction.Forward;
                    }
                    Motor.Interface.Rotation(exdir, 1, 10);
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    System.Threading.Thread.Sleep(2 * wait);
                    Camera.Interface.GetSideLuminosity(area, area, out top, out bottom, out left, out right);
                    Display.Console.WriteLine(DisplayMode.DeviceFilterState, "confseq := limit{0,3}, left{1,3}, right{2,3}", limit, (int)left, (int)right);
                    if (left >= limit && right >= limit)
                    {
                        complete = true;
                    }
                }
            }
        }

        private void AdjustProcess(int direction, int step, int limit, int area)
        {
            FitFilterProcess(true, -direction, step, limit, area, 1000);
            FitFilterProcess(true, direction, step, limit, area, 1000);
        }
        #endregion
    }
}
