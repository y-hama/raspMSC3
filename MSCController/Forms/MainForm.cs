using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCController.Forms
{
    public partial class MainForm : Form
    {
        private bool Request_ControllerEnable { get; set; }
        private string ControllStatusMessage { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Model.Sequence.Interface.AdjustFilterFinished += FilterActionCompleted;
            Model.Sequence.Interface.MoveFilterFinished += FilterActionCompleted;
            Model.Sequence.Interface.TakeFrameFinished += FilterActionCompleted;

            Model.Sequence.Interface.StartMonitor();
        }

        private void ConrtollerDisable()
        {
            ControlerPanel.Enabled = false;
        }

        private void ConrtollerEnable()
        {
            Request_ControllerEnable = true;
        }

        private void FilterActionCompleted(bool isCanceled, Model.Sequence.Action action)
        {
            ControllStatusMessage = (action.ToString()) + " finished.";
            if (isCanceled)
            {
                ControllStatusMessage += "(cancel)";
            }
            ConrtollerEnable();

            switch (action)
            {
                case Model.Sequence.Action.TalkeFrame:
                    {
                        Imaging.Event.Interface.SaveObject(TakeFileName.Text);
                    }
                    break;
                case Model.Sequence.Action.MoveFilter:
                    break;
                case Model.Sequence.Action.AdjustFIlter:
                    break;
                default:
                    break;
            }
        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            Bitmap bitmap;
            if (Imaging.Convertor.GetLatestImage(out bitmap, MonitorFrameBox.Width, MonitorFrameBox.Height))
            {
                MonitorFrameBox.Image = bitmap;
            }

            FpsLabel.Text = string.Format("{0}fps", (int)Imaging.Event.Interface.FPS);
            int w, h, c;
            Imaging.Convertor.GetLatestImageSize(out c, out w, out h);
            SizeLabel.Text = string.Format("c:{0}, w:{1}, h:{2}", c, w, h);
            ControllStatusLabel.Text = ControllStatusMessage;

            if (Request_ControllerEnable)
            {
                Request_ControllerEnable = false;
                ControlerPanel.Enabled = true;
            }
        }

        private void MoveNextButton_Click(object sender, EventArgs e)
        {
            ControllStatusMessage = "Move Working.";
            ConrtollerDisable();
            Model.Sequence.Interface.StartMoveFilter(Model.Sequence.MoveDirection.Forwerd);
        }

        private void MoveBackButton_Click(object sender, EventArgs e)
        {
            ControllStatusMessage = "Move Working.";
            ConrtollerDisable();
            Model.Sequence.Interface.StartMoveFilter(Model.Sequence.MoveDirection.Back);
        }

        private void AdjustButton_Click(object sender, EventArgs e)
        {
            ControllStatusMessage = "Adjust Working.";
            ConrtollerDisable();
            Model.Sequence.Interface.StartAdjustFilter();
        }

        private void CanceleButton_Click(object sender, EventArgs e)
        {
            Model.Sequence.Interface.StopFilter();
        }

        private void TakeFrameButton_Click(object sender, EventArgs e)
        {
            if (TakeFileName.Text == string.Empty)
            {
                ControllStatusMessage = "Filename is Empty.";
                return;
            }
            ControllStatusMessage = "TakeFrame Working.";
            Model.Sequence.Interface.StartTakeFrame();
        }
    }
}
