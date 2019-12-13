using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum DisplayMode
{
    Debug,
    System01,
    System02,
    System03,
    ApplicationStatus,
    CommunicationState,
    CommunicationError,
    CommunicationLatestRecievedMessage,
    CommunicationLatestSendMessage,
    DeviceGPIOState,
    DeviceGPIOPinState,
    DeviceFilterState,
    DeviceCameraState,
}

class DisplaySet
{
    public DisplayMode Mode { get; private set; }
    public int Line { get; private set; }

    public string Message { get; set; }

    public string Header { get; set; }

    public DisplaySet(DisplayMode mode, string header, int line)
    {
        Mode = mode; Header = header; Line = line;
    }
}

static class DisplayCore
{
    public static List<DisplaySet> ItemSet { get; private set; } = new List<DisplaySet>()
    {
        new DisplaySet(DisplayMode.Debug,                               "  dbgmsg", 1),
        new DisplaySet(DisplayMode.System01,                            "        ", 2),
        new DisplaySet(DisplayMode.System02,                            "        ", 3),
        new DisplaySet(DisplayMode.System03,                            "        ", 4),
        new DisplaySet(DisplayMode.ApplicationStatus,                   "   appst", 5),
        new DisplaySet(DisplayMode.CommunicationState,                  "   comst", 6),
        new DisplaySet(DisplayMode.CommunicationError,                  "   comer", 7),
        new DisplaySet(DisplayMode.CommunicationLatestSendMessage,      "  sndmsg", 8),
        new DisplaySet(DisplayMode.CommunicationLatestRecievedMessage,  "  recmsg", 9),
        new DisplaySet(DisplayMode.DeviceGPIOState,                     "  gpiost", 10),
        new DisplaySet(DisplayMode.DeviceGPIOPinState,                  "   pinst", 11),
        new DisplaySet(DisplayMode.DeviceFilterState,                   "   fltst", 12),
        new DisplaySet(DisplayMode.DeviceCameraState,                   "   camst", 13),
    };
}