using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MSCController.Forms
{
    public partial class MainForm : Form
    {
        private bool Request_ControllerEnable { get; set; } = false;
        private bool Request_ImageListRefresh { get; set; } = false;
        private bool Request_CompletedAction { get; set; } = false;
        private string ControllStatusMessage { get; set; } = string.Empty;
        private int FilterControllProgressValue { get; set; } = 0;

        private int MarkerSize { get; set; } = 10;
        private Point SelectRedPoint { get; set; }
        private Point SelectBluePoint { get; set; }

        private Bitmap MainviewImage { get; set; } = null;

        public MainForm()
        {
            InitializeComponent();
            Model.Sequence.Interface.AdjustFilterFinished += FilterActionCompleted;
            Model.Sequence.Interface.MoveFilterFinished += FilterActionCompleted;
            Model.Sequence.Interface.TakeFrameFinished += FilterActionCompleted;
            Model.Sequence.Interface.TakeFrameStepCompleted += Interface_TakeFrameStepCompleted;

            Imaging.Image.Channels.ActionCompleted += Channels_ActionCompleted;

            ImageListRefresh();

            LimitValue.Value = Model.Sequence.Interface.SideLimit;
            LimitValueLabel.Text = LimitValue.Value.ToString();
        }

        #region PrivateMethod
        private void ConrtollerDisable()
        {
            ControlerPanel.Enabled = false;
            FilterControllProgressValue = 0;
        }

        private void ConrtollerEnable()
        {
            Request_ControllerEnable = true;
            FilterControllProgressValue = 100;
        }

        private void ImageListRefresh()
        {
            ImageList.Items.Clear();
            foreach (var item in Imaging.Store.Instance.GetImageNames())
            {
                ImageList.Items.Add(item);
            }
        }

        private void SpectrumListRefresh()
        {
            if (Imaging.Store.Instance.SpectrumCount >= 0)
            {
                SpectrumList.Items.Clear();
                for (int i = 0; i < Imaging.Store.Instance.SpectrumCount; i++)
                {
                    string name = Imaging.Store.Instance.GetProperty(i).Name;
                    if (name == null || name == string.Empty)
                    {
                        name = "frame" + i.ToString();
                    }
                    else
                    {
                        name = "(" + string.Format("{0,2}", i) + ")" + name;
                    }
                    SpectrumList.Items.Add(name);
                }
                SpectrumList.SelectedIndex = 0;

                UpdateSelectionChart();
            }
        }

        private void PutPoint(Point p, Color c, ref Bitmap bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.FillEllipse(new SolidBrush(Color.FromArgb(100, c)), new Rectangle(p.X - MarkerSize / 2, p.Y - MarkerSize / 2, MarkerSize, MarkerSize));
        }

        private Bitmap PutSelectPoint()
        {
            Bitmap btm = (Bitmap)MainviewImage.Clone();
            PutPoint(SelectRedPoint, Color.Red, ref btm);
            PutPoint(SelectBluePoint, Color.Blue, ref btm);
            return btm;
        }

        private Bitmap PutSelectLine()
        {
            Bitmap btm = new Bitmap(BackgroundviewPanel.Width, BackgroundviewPanel.Height);
            Graphics g = Graphics.FromImage(btm);
            g.FillRectangle(Brushes.Black, new Rectangle(new Point(), btm.Size));
            g.DrawLine(Pens.Red,
                new Point(SelectRedPoint.X + MainviewPanel.Location.X, 0),
                new Point(SelectRedPoint.X + MainviewPanel.Location.X, BackgroundviewPanel.Height));
            g.DrawLine(Pens.Red,
                new Point(0, SelectRedPoint.Y + MainviewPanel.Location.Y),
                new Point(BackgroundviewPanel.Width, SelectRedPoint.Y + MainviewPanel.Location.Y));

            g.DrawLine(Pens.Blue,
                new Point(SelectBluePoint.X + MainviewPanel.Location.X, 0),
                new Point(SelectBluePoint.X + MainviewPanel.Location.X, BackgroundviewPanel.Height));
            g.DrawLine(Pens.Blue,
                new Point(0, SelectBluePoint.Y + MainviewPanel.Location.Y),
                new Point(BackgroundviewPanel.Width, SelectBluePoint.Y + MainviewPanel.Location.Y));
            return btm;
        }

        private void UpdateSelectionChart()
        {
            Series RedSelection = SpectrumChart.Series["RedSelection"];
            Series BlueSelection = SpectrumChart.Series["BlueSelection"];

            SpectrumChart.ChartAreas[0].AxisX.Maximum = Imaging.Store.Instance.SpectrumCount - 1;

            RedSelection.Points.Clear();
            BlueSelection.Points.Clear();

            for (int i = 0; i < Imaging.Store.Instance.SpectrumCount; i++)
            {
                RedSelection.Points.AddXY(i, Imaging.Store.Instance.GetBrightness(i, SelectRedPoint.X, SelectRedPoint.Y));
                BlueSelection.Points.AddXY(i, Imaging.Store.Instance.GetBrightness(i, SelectBluePoint.X, SelectBluePoint.Y));
            }
        }
        #endregion

        #region SequenceEvent
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
                        Request_ImageListRefresh = true;
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

        private void Interface_TakeFrameStepCompleted(int stepnum, int stepmax)
        {
            ControllStatusMessage = "TakeFrame Working. Completed => " + stepnum.ToString();
            FilterControllProgressValue = Math.Min(100, (int)(100 * (double)(1 + stepnum) / stepmax));
        }
        #endregion

        #region ControllEvent
        private void ContorollTimer_Tick(object sender, EventArgs e)
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
            if (Request_ImageListRefresh)
            {
                Request_ImageListRefresh = false;
                ImageListRefresh();
            }
            if (Request_CompletedAction)
            {
                Request_CompletedAction = false;
                AlignmentButton.Enabled = true;
                StretchButton.Enabled = true;
                MainviewImage = Imaging.Store.Instance.GetBitmap(SpectrumList.SelectedIndex);

                if (MainviewImage != null)
                {
                    Bitmap refreshimage = PutSelectPoint();
                    MainviewPanel.Image = refreshimage;
                    UpdateSelectionChart();
                }
            }

            if (IF.Instance.Com.IsConnected)
            {
                ReconnectButton.Enabled = false;
                ControllerGroup.Enabled = true;
            }
            else
            {
                ReconnectButton.Enabled = true;
                ControllerGroup.Enabled = false;
            }
            FilterControllProgress.Value = FilterControllProgressValue;
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
            ConrtollerDisable();
            Model.Sequence.Interface.StartTakeFrame();
        }

        private void ReconnectButton_Click(object sender, EventArgs e)
        {
            IF.Instance.CreateCommunication();
        }

        private void ExtructButton_Click(object sender, EventArgs e)
        {
            if (ImageList.Items.Count > 0 && ImageList.SelectedIndex >= 0)
            {
                string name = ImageList.Items[ImageList.SelectedIndex].ToString();
                SaveFileName.Text = name;
                Imaging.Image.ColorMode mode = OptionColorBox.Checked ? Imaging.Image.ColorMode.RGB : Imaging.Image.ColorMode.Gary;
                Imaging.Store.Instance.SetSelectedImage(name, mode);
                SpectrumListRefresh();
                SpectrumList.Select();
            }
        }

        private void SpectrumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SpectrumList.SelectedIndex >= 0)
            {
                MainviewImage = Imaging.Store.Instance.GetBitmap(SpectrumList.SelectedIndex);

                MainviewPanel.Image = PutSelectPoint();
                BackgroundviewPanel.Image = PutSelectLine();
                UpdateSelectionChart();
            }
        }

        private void MainviewPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= 0 && e.X < MainviewPanel.Width && e.Y >= 0 && e.Y < MainviewPanel.Height)
            {
                ToolStripLocationLabel.Text = string.Format("({0}, {1})", e.X, e.Y);
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        {
                            SelectRedPoint = e.Location;
                            ToolStripPointRedLabel.Text = string.Format("({0}, {1})", e.X, e.Y);
                        }
                        break;
                    case MouseButtons.None:
                        break;
                    case MouseButtons.Right:
                        {
                            SelectBluePoint = e.Location;
                            ToolStripPointBlueLabel.Text = string.Format("({0}, {1})", e.X, e.Y);
                        }
                        break;
                    case MouseButtons.Middle:
                        break;
                    case MouseButtons.XButton1:
                        break;
                    case MouseButtons.XButton2:
                        break;
                    default:
                        break;
                }
                if (MainviewImage != null)
                {
                    MainviewPanel.Image = PutSelectPoint();
                    BackgroundviewPanel.Image = PutSelectLine();
                    UpdateSelectionChart();
                }
            }
        }

        private void MainviewPanel_MouseUp(object sender, MouseEventArgs e)
        {
            MainviewPanel_MouseMove(sender, e);
        }

        private void StretchButton_Click(object sender, EventArgs e)
        {
            byte min, max;
            if (byte.TryParse(MinBrightnessLabel.Text, out min) && byte.TryParse(MaxBrightnessLabel.Text, out max))
            {
                AlignmentButton.Enabled = false;
                StretchButton.Enabled = false;
                new Task(() => { Imaging.Store.Instance.Stretch(min, max); }).Start();
            }
        }
        private void AlignmentButton_Click(object sender, EventArgs e)
        {
            byte target;
            if (byte.TryParse(TargetLabel.Text, out target))
            {
                AlignmentButton.Enabled = false;
                StretchButton.Enabled = false;
                new Task(() => { Imaging.Store.Instance.Alignment(SelectBluePoint.X, SelectBluePoint.Y, MarkerSize, target); }).Start();
            }
        }
        private void Channels_ActionCompleted()
        {
            Request_CompletedAction = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveFileName.Text == string.Empty)
            {
                MessageBox.Show("SaveFileName is Empty.");
                return;
            }

            if (!Imaging.Store.Instance.Save(SaveFileName.Text))
            {
                MessageBox.Show("Imae isnot Load.");
            }
            else
            {
                ImageListRefresh();
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (SpectrumList.SelectedIndex < 0 || FilterList.SelectedIndex < 0)
            {
                return;
            }

            List<string> names = new List<string>();
            foreach (var item in FilterList.Items)
            {
                names.Add(item.ToString());
            }
            Imaging.Store.Instance.Remane(SpectrumList.SelectedIndex, FilterList.SelectedIndex, names);

            SpectrumListRefresh();
        }

        private void SpectrumList_MouseEnter(object sender, EventArgs e)
        {
            FilterList.Width = SpectrumList.Width;
        }

        private void FilterList_MouseLeave(object sender, EventArgs e)
        {
            FilterList.Width = 0;
        }

        private void LimitValue_Scroll(object sender, EventArgs e)
        {
            Model.Sequence.Interface.SideLimit = LimitValue.Value;
            LimitValueLabel.Text = LimitValue.Value.ToString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IF.Instance.Com.IsConnected)
            {
                if (MessageBox.Show("Do you want to turn off the device ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Model.Sequence.Interface.DeviceTurnOFF();
                }
            }
        }

        private void ImageList_DoubleClick(object sender, EventArgs e)
        {
            ImageListRefresh();
        }
        #endregion
    }
}
