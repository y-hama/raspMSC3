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
    public partial class TestForm : Form
    {
        #region Form
        public TestForm()
        {
            InitializeComponent();

            IF.Instance.Com.Send(Communication.Command.Create("camstart", null));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = string.Format("({0}fps)", (int)Imaging.Event.Interface.FPS);
            label2.Text = string.Empty;
            Bitmap bitmap;
            if (Imaging.Convertor.GetLatestImage(out bitmap))
            {
                pictureBox1.Image = bitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Sequence.Interface.StartTakeFrame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model.Sequence.Interface.StopFilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Model.Sequence.Interface.StartAdjustFilter();
        }

        private void AdjustFilterFinished(bool isCanceled)
        {
            if (!isCanceled)
            {

            }
        }

        private void Interface_TakeFrameFinished(bool isCanceled)
        {
            if (!isCanceled)
            {
                Imaging.Event.Interface.SaveObject(textBox1.Text);
            }
        }

        #endregion

    }
}
