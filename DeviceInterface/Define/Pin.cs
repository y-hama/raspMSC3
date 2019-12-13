using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace DeviceInterface.Define
{
    public class Pin
    {
        private const string EXPORT_FORMAT = @"/sys/class/gpio/export";
        private const string DIR_FORMAT = @"/sys/class/gpio/gpio{0}";
        private const string DIRECTION_FORMAT = @"/sys/class/gpio/gpio{0}/direction";
        private const string VALUE_FORMAT = @"/sys/class/gpio/gpio{0}/value";
        private const string UNEXPORT_FORMAT = @"/sys/class/gpio/unexport";

        public int ID { get; private set; }
        public bool IsOpened { get; private set; }

        public GPIO.Direction Direction { get; private set; }
        private GPIO.Value _value { get; set; }
        public GPIO.Value Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == GPIO.Value.Undefined) { return; }
                switch (Direction)
                {
                    case GPIO.Direction.Read:
                        break;
                    case GPIO.Direction.Write:
                        this._value = value;

#if !DEBUG
                        string vpath = string.Format(VALUE_FORMAT, ID);
                        using (StreamWriter sw = new StreamWriter(vpath))
                        {
                            sw.Write(value == GPIO.Value.High ? "1" : "0");
                            sw.Close();
                        }
#endif
                        Display.Console.WriteLine(DisplayMode.DeviceGPIOPinState, "Pin -> {0,-8} SetValue : {1}", ID, value.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        public Pin(int id)
        {
            ID = id;
        }

        public void Export(GPIO.Direction direction)
        {
            Display.Console.WriteLine(DisplayMode.DeviceGPIOPinState, "Pin -> " + ID.ToString() + " Export.");
            Direction = direction;
            string dir = direction == GPIO.Direction.Write ? "out" : "in";

#if !DEBUG
            string export = EXPORT_FORMAT;
            string directory = string.Format(DIR_FORMAT, ID);
            string direct = string.Format(DIRECTION_FORMAT, ID);

            if (!Directory.Exists(directory))
            {
                using (StreamWriter sw = new StreamWriter(export))
                {
                    sw.Write(ID);
                    sw.Close();
                }
                while (!Directory.Exists(directory)) { System.Threading.Thread.Sleep(10); }
                System.Threading.Thread.Sleep(100);
            }

            using (StreamWriter sw = new StreamWriter(direct))
            {
                sw.Write(dir);
                sw.Close();
            }
#endif

            Display.Console.WriteLine(DisplayMode.DeviceGPIOPinState, "Pin -> " + ID.ToString() + " open.");
#if !DEBUG
            switch (direction)
            {
                case GPIO.Direction.Read:
                    _value = Value;
                    (new System.Threading.Tasks.Task(() =>
                    {
                        GPIO.Value pVal = GPIO.Value.Undefined;
                        bool init = false;
                        while (true)
                        {
                            string v = "-1";
                            string vpath = string.Format(VALUE_FORMAT, ID);
                            using (FileStream fs = new FileStream(vpath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                            {
                                var sr = new StreamReader(fs, Encoding.UTF8);
                                {
                                    v = sr.ReadLine();
                                }
                            }
                            _value = ((v == "0") ? GPIO.Value.High : (v == "1" ? GPIO.Value.Low : GPIO.Value.Undefined));
                            if (!init) { pVal = _value; init = true; }
                            else
                            {
                                if (pVal != _value)
                                {
                                    GPIO.RizeEvent_ReadPinStateChanged(ID, pVal, _value);
                                }
                                pVal = _value;
                            }
                            System.Threading.Thread.Sleep(10);
                        }
                    })).Start();
                    break;
                case GPIO.Direction.Write:
                    Value = GPIO.Value.Low;
                    break;
                default:
                    break;
            }
#endif
            IsOpened = true;
        }

        public void Unexport()
        {
            IsOpened = false;
            using (StreamWriter fs = new StreamWriter(UNEXPORT_FORMAT))
            {
                fs.Write(ID.ToString());
            }
        }
    }
}
