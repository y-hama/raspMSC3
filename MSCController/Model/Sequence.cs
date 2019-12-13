using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCController.Model
{
    class Sequence
    {
        private static Sequence instance = new Sequence();
        public static Sequence Interface { get { return instance; } }
        private Sequence() { }

        public delegate void SequenceCompletedEventHandler();

        public void StopFilter()
        {
            TakeFrameWorking = false;
            NextFilterWorking = false;
            AdjustFilterWorking = false;
        }

        #region TakeFrame
        private bool TakeFrameWorking { get; set; } = false;
        private bool camStopCompleted_TakeFrame { get; set; }
        private bool nextfiltercompleted_TakeFrame { get; set; }

        private SequenceCompletedEventHandler TakeFrameSequenceCompletedHandler;
        public event SequenceCompletedEventHandler TakeFrameCompleted
        {
            add { TakeFrameSequenceCompletedHandler = value; }
            remove { TakeFrameSequenceCompletedHandler = value; }
        }

        public void TakeFrameProcessTask()
        {
            if (TakeFrameWorking) { return; }
            TakeFrameWorking = true;
            int filternum = 16;
            while (TakeFrameWorking && filternum > 0)
            {
                camStopCompleted_TakeFrame = false;
                while (!camStopCompleted_TakeFrame)
                {
                    IF.Instance.Com.Send(Communication.Command.CreateWithResponse("camstop", com_CamStoptCompleted_TakeFrame, null));
                    System.Threading.Thread.Sleep(50);
                }

                nextfiltercompleted_TakeFrame = false;
                IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtnext", com_FiltNextCompleterd_TakeFrame, null, 1, 32, 50, 2));
                while (!nextfiltercompleted_TakeFrame) { System.Threading.Thread.Sleep(50); if (!TakeFrameWorking) { break; } }

                if (!TakeFrameWorking)
                {
                    IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtterm", com_FiltNextCompleterd_TakeFrame, null));
                    while (!nextfiltercompleted_TakeFrame) { System.Threading.Thread.Sleep(50); }
                }

                IF.Instance.Com.Send(Communication.Command.Create("camstart", null));
                System.Threading.Thread.Sleep(500);
                filternum--;
            }
            TakeFrameWorking = false;
            TakeFrameSequenceCompletedHandler?.Invoke();
        }

        private void com_CamStoptCompleted_TakeFrame(Communication.Command command)
        {
            camStopCompleted_TakeFrame = true;
        }

        private void com_FiltNextCompleterd_TakeFrame(Communication.Command command)
        {
            nextfiltercompleted_TakeFrame = true;
        }
        #endregion

        #region NextFilter
        private bool NextFilterWorking { get; set; } = false;
        private bool nextfiltercompleted_NextFilter { get; set; }

        private SequenceCompletedEventHandler NextFilterSequenceCompletedHandler;
        public event SequenceCompletedEventHandler NextFilterCompleted
        {
            add { NextFilterSequenceCompletedHandler = value; }
            remove { NextFilterSequenceCompletedHandler = value; }
        }

        public void NextFilterProcessTask()
        {
            if (NextFilterWorking) { return; }
            NextFilterWorking = true;
            nextfiltercompleted_NextFilter = false;
            IF.Instance.Com.Send(Communication.Command.Create("camstart", null, 200));

            IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtnext", com_FiltNextCompleterd_NextFilter, null, 1, 32, 50, 2));
            while (!nextfiltercompleted_NextFilter) { System.Threading.Thread.Sleep(50); if (!NextFilterWorking) { break; } }

            if (!NextFilterWorking)
            {
                IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtterm", com_FiltNextCompleterd_NextFilter, null));
                while (!nextfiltercompleted_NextFilter) { System.Threading.Thread.Sleep(50); }
            }

            IF.Instance.Com.Send(Communication.Command.Create("camstart", null));
            NextFilterWorking = false;
            NextFilterSequenceCompletedHandler?.Invoke();
        }

        private void com_FiltNextCompleterd_NextFilter(Communication.Command command)
        {
            nextfiltercompleted_NextFilter = true;
        }
        #endregion

        #region AdjustFilter 
        private bool AdjustFilterWorking { get; set; } = false;
        private bool camStopCompleted_AdjustFilter { get; set; }
        private bool adjustfiltercompleted_AdjustFilter { get; set; }

        private SequenceCompletedEventHandler AdjustFilterSequenceCompletedHandler;
        public event SequenceCompletedEventHandler AdjustFilterCompleted
        {
            add { AdjustFilterSequenceCompletedHandler = value; }
            remove { AdjustFilterSequenceCompletedHandler = value; }
        }

        public void AdjustFilterProcessTask()
        {
            if (AdjustFilterWorking) { return; }
            AdjustFilterWorking = true;
            adjustfiltercompleted_AdjustFilter = false;
            IF.Instance.Com.Send(Communication.Command.Create("camstart", null, 200));

            IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtadjust", com_AdjustFilterCompleterd_AdjustFilter, null, 1, 32, 50, 2));
            while (!adjustfiltercompleted_AdjustFilter) { System.Threading.Thread.Sleep(50); if (!AdjustFilterWorking) { break; } }

            if (!AdjustFilterWorking)
            {
                IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtterm", com_AdjustFilterCompleterd_AdjustFilter, null));
                while (!adjustfiltercompleted_AdjustFilter) { System.Threading.Thread.Sleep(50); }
            }

            IF.Instance.Com.Send(Communication.Command.Create("camstart", null));
            AdjustFilterWorking = false;
            AdjustFilterSequenceCompletedHandler?.Invoke();
        }

        private void com_AdjustFilterCompleterd_AdjustFilter(Communication.Command command)
        {
            adjustfiltercompleted_AdjustFilter = true;
        }
        #endregion
    }
}
