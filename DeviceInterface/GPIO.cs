using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceInterface
{

    public class GPIO
    {
        public delegate void ReadPinStateChangedEventMethod(ReadPinStateChangedEventArgs e);
        private static ReadPinStateChangedEventMethod ReadPinStateChangedEventHandler { get; set; }
        public static event ReadPinStateChangedEventMethod ReadPinStateChanged
        {
            add { ReadPinStateChangedEventHandler += value; }
            remove { ReadPinStateChangedEventHandler -= value; }
        }
        public class ReadPinStateChangedEventArgs
        {
            public int ID { get; private set; }
            public Value PrevValue { get; private set; }
            public Value NewValue { get; private set; }
            public ReadPinStateChangedEventArgs(int id, Value preVal, Value newVal)
            {
                ID = id; PrevValue = preVal; NewValue = newVal;
            }
        }
        public static void RizeEvent_ReadPinStateChanged(int id, Value preVal, Value newVal)
        {
            if (ReadPinStateChangedEventHandler != null)
            {
                ReadPinStateChangedEventHandler(new ReadPinStateChangedEventArgs(id, preVal, newVal));
            }
        }

        public enum Direction
        {
            Read,
            Write,
        }
        public enum Value
        {
            Undefined,
            Low,
            High,
        }

        private static GPIO pins = new GPIO();
        public static GPIO Pins { get { return pins; } }
        private GPIO() { }

        private List<Define.Pin> pList { get; set; } = null;

        public void Initialize()
        {
            if (pList == null)
            {
                pList = new List<Define.Pin>();
                Display.Console.WriteLine(DisplayMode.DeviceGPIOState, "GPIO Available.");
            }
        }

        private Define.Pin GetPin(int id)
        {
            Define.Pin pin;
            if ((pin = pList.Find(x => x.ID == id)) != null)
            {
                return pin;
            }
            return null;
        }
        private void SetPin(int id, Define.Pin pin)
        {
            int rep = -1;
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i].ID == id) { rep = i; break; }
            }
            if (rep >= 0) { pList[rep] = pin; }
        }

        public void Open(int id, Direction direction)
        {
            Define.Pin pin;
            if ((pin = pList.Find(x => x.ID == id)) == null)
            {
                pin = new Define.Pin(id);
            }
            else { pin.Unexport(); }
            pin.Export(direction);
            pList.Add(pin);
        }
        public void Close(int id)
        {
            Define.Pin pin;
            if ((pin = pList.Find(x => x.ID == id)) != null)
            {
                pin.Unexport();
            }
            pList.Remove(pin);
        }

        public bool IsOpened(int id)
        {
            var pin = GetPin(id);
            if (pin != null && pin.IsOpened)
            { return true; }
            else { return false; }
        }

        public Value this[int id]
        {
            get
            {
                Value ret = Value.Low;
                Define.Pin pin;
                if ((pin = GetPin(id)) != null)
                {
                    if (pin.IsOpened) { ret = pin.Value; }
                }
                return ret;
            }
            set
            {
                Define.Pin pin;
                if ((pin = GetPin(id)) != null)
                {
                    if (pin.IsOpened) { pin.Value = value; }
                }
            }
        }

    }
}
