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

        public enum MoveDirection
        {
            Forwerd = 1,
            Back = -1,
        }

        public enum Action
        {
            TalkeFrame,
            MoveFilter,
            AdjustFIlter,
        }

        public delegate void SequenceCompletedEventHandler(bool isCanceled, Action action);

        private int SideLimit { get; set; } = 60;
        private int SideArea { get; set; } = 3;

        private const int INITIALRATE = 25;
        private int BaseFrameRate { get; set; } = INITIALRATE;

        public void StopFilter()
        {
            IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtterm", com_StopFilterCompleted, null));
        }

        private void com_StopFilterCompleted(Communication.Command command)
        {
            TakeFrameWorking = false;
            MoveFilterWorking = false;
            AdjustFilterWorking = false;
        }
        #region  Monitor

        public void StartMonitor(int rate = INITIALRATE)
        {
            IF.Instance.Com.Send(Communication.Command.Create("camstart", null, (int)(1000 / rate)));
        }
        private bool camStopCompleted { get; set; }
        public void StopMonitor()
        {
            camStopCompleted = false;
            while (!camStopCompleted)
            {
                IF.Instance.Com.Send(Communication.Command.CreateWithResponse("camstop", com_CamStoptCompleted, null));
                System.Threading.Thread.Sleep(50);
            }
        }

        private void com_CamStoptCompleted(Communication.Command command)
        {
            camStopCompleted = true;
        }


        #endregion

        #region TakeFrame
        private bool TakeFrameWorking { get; set; } = false;
        private bool nextfiltercompleted_TakeFrame { get; set; }
        private int FrameCount { get; set; }

        private SequenceCompletedEventHandler TakeFrameSequenceFinishedHandler;
        public event SequenceCompletedEventHandler TakeFrameFinished
        {
            add { TakeFrameSequenceFinishedHandler = value; }
            remove { TakeFrameSequenceFinishedHandler = value; }
        }

        public delegate void StepCompletedEventHandler(int stepnum);
        private StepCompletedEventHandler TakeFrameStepCompletedHandler;
        public event StepCompletedEventHandler TakeFrameStepCompleted
        {
            add { TakeFrameStepCompletedHandler = value; }
            remove { TakeFrameStepCompletedHandler = value; }
        }

        public void StartTakeFrame(int framecount = 16)
        {
            FrameCount = framecount;
            new Task(TakeFrameProcessTask).Start();
        }

        private void TakeFrameProcessTask()
        {
            if (TakeFrameWorking) { return; }
            TakeFrameWorking = true;
            int filternum = FrameCount;
            Imaging.Event.Interface.CreateNewImageObject();
            while (TakeFrameWorking && filternum > 0)
            {
                StopMonitor();

                nextfiltercompleted_TakeFrame = false;
                IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtnext", com_FiltNextCompleterd_TakeFrame, null, (int)MoveDirection.Forwerd, 32, SideLimit, SideArea));
                while (!nextfiltercompleted_TakeFrame) { System.Threading.Thread.Sleep(50); if (!TakeFrameWorking) { break; } }

                StartMonitor(BaseFrameRate);
                System.Threading.Thread.Sleep(500);
                if (TakeFrameWorking)
                {
                    Imaging.Event.Interface.AddLatestFrame();
                    TakeFrameStepCompletedHandler?.Invoke(FrameCount - filternum);
                }
                filternum--;
            }
            TakeFrameSequenceFinishedHandler?.Invoke(!TakeFrameWorking, Action.TalkeFrame);
            TakeFrameWorking = false;
        }

        private void com_FiltNextCompleterd_TakeFrame(Communication.Command command)
        {
            nextfiltercompleted_TakeFrame = true;
        }
        #endregion

        #region MoveFilter
        private bool MoveFilterWorking { get; set; } = false;
        private bool moveFiltercompleted_NextFilter { get; set; }
        private MoveDirection movefilter_Direction { get; set; }

        private SequenceCompletedEventHandler MoveFilterSequenceFinishedHandler;
        public event SequenceCompletedEventHandler MoveFilterFinished
        {
            add { MoveFilterSequenceFinishedHandler = value; }
            remove { MoveFilterSequenceFinishedHandler = value; }
        }

        public void StartMoveFilter(MoveDirection direction)
        {
            movefilter_Direction = direction;
            new Task(MoveFilterProcessTask).Start();
        }

        private void MoveFilterProcessTask()
        {
            if (MoveFilterWorking) { return; }
            MoveFilterWorking = true;
            moveFiltercompleted_NextFilter = false;
            StartMonitor(BaseFrameRate / 10);

            IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtnext", com_FiltMoveCompleterd_NextFilter, null, (int)movefilter_Direction, 32, SideLimit, SideArea));
            while (!moveFiltercompleted_NextFilter) { System.Threading.Thread.Sleep(50); if (!MoveFilterWorking) { break; } }

            StartMonitor(BaseFrameRate);
            MoveFilterSequenceFinishedHandler?.Invoke(!MoveFilterWorking, Action.MoveFilter);
            MoveFilterWorking = false;
        }

        private void com_FiltMoveCompleterd_NextFilter(Communication.Command command)
        {
            moveFiltercompleted_NextFilter = true;
        }
        #endregion

        #region AdjustFilter 
        private bool AdjustFilterWorking { get; set; } = false;
        private bool camStopCompleted_AdjustFilter { get; set; }
        private bool adjustfiltercompleted_AdjustFilter { get; set; }

        private SequenceCompletedEventHandler AdjustFilterSequenceFinishedHandler;
        public event SequenceCompletedEventHandler AdjustFilterFinished
        {
            add { AdjustFilterSequenceFinishedHandler = value; }
            remove { AdjustFilterSequenceFinishedHandler = value; }
        }

        public void StartAdjustFilter()
        {
            new Task(AdjustFilterProcessTask).Start();
        }

        private void AdjustFilterProcessTask()
        {
            if (AdjustFilterWorking) { return; }
            AdjustFilterWorking = true;
            adjustfiltercompleted_AdjustFilter = false;
            StartMonitor(BaseFrameRate / 10);

            IF.Instance.Com.Send(Communication.Command.CreateWithResponse("filtadjust", com_AdjustFilterCompleterd_AdjustFilter, null, (int)MoveDirection.Forwerd, 32, SideLimit, SideArea));
            while (!adjustfiltercompleted_AdjustFilter) { System.Threading.Thread.Sleep(50); if (!AdjustFilterWorking) { break; } }

            StartMonitor(BaseFrameRate);
            AdjustFilterSequenceFinishedHandler?.Invoke(!AdjustFilterWorking, Action.AdjustFIlter);
            AdjustFilterWorking = false;
        }

        private void com_AdjustFilterCompleterd_AdjustFilter(Communication.Command command)
        {
            adjustfiltercompleted_AdjustFilter = true;
        }
        #endregion
    }
}
