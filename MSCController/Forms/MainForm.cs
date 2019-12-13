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
        #region Form
        private int reccount = 0;
        private string latestmsg = string.Empty;
        private string restext = string.Empty;

        private double elipsedtime { get; set; } = 0;
        private DateTime stamp { get; set; } = DateTime.Now;

        private object __lockobj = new object();
        Bitmap latestimage { get; set; }

        public MainForm()
        {
            InitializeComponent();
            IF.Instance.Com.DataRecieved += Com_DataRecieved;
            IF.Instance.Com.ImageRecieved += Com_ImageRecieved;

            Model.Sequence.Interface.AdjustFilterCompleted += AdjustTaskCompleted;

            IF.Instance.Com.Send(Communication.Command.Create("camstart", null));
        }

        private void Com_ImageRecieved(Bitmap frame)
        {
            lock (__lockobj)
            {
                latestimage = frame;
            }
            elipsedtime = (DateTime.Now - stamp).TotalMilliseconds;
            stamp = DateTime.Now;
        }

        private void Com_DataRecieved(Communication.Command cmd)
        {
            reccount++;
            latestmsg = cmd.ID;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = string.Format("{0}({1}fps) : {2}", reccount, (int)(1000.0 / elipsedtime), latestmsg);
            label2.Text = restext;
            lock (__lockobj)
            {
                if (latestimage != null)
                {
                    pictureBox1.Image = (Bitmap)latestimage.Clone();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Task(Model.Sequence.Interface.TakeFrameProcessTask).Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model.Sequence.Interface.StopFilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Task(Model.Sequence.Interface.AdjustFilterProcessTask).Start();
        }

        private void AdjustTaskCompleted()
        {
        }
        #endregion

    }
}
