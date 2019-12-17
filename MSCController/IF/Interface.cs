using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCController.IF
{
    class Interface : Communication.Client
    {
        #region Event
        public delegate void ImageRecievedEventHandler(byte[] data, int channels, int width, int height);
        protected static ImageRecievedEventHandler ImageRecievedEvent { get; set; }
        public event ImageRecievedEventHandler ImageRecieved
        {
            add { ImageRecievedEvent += value; }
            remove { ImageRecievedEvent -= value; }
        }
        #endregion

        #region Mode
        public enum ImageRequestMode
        {
            Frame,
            Movie,
        }
        public static ImageRequestMode ImageRequest { get; set; } = ImageRequestMode.Movie;
        #endregion

        protected override void CreateCommandTable()
        {
            AddCommand(Communication.CommandDefine.CreateDefine("resim", 3, ResponceImage));
        }


        private static Communication.Command ResponceImage(Communication.Command command)
        {
            //new Task(() =>
            {
                try
                {
                    int ch, w, h;
                    ch = Convert.ToInt32(command.Parameter[0]);
                    w = Convert.ToInt32(command.Parameter[1]);
                    h = Convert.ToInt32(command.Parameter[2]);
                    if (ch * w * h == command.Data.Length)
                    {
                        ImageRecievedEvent?.Invoke((byte[])command.Data.Clone(), ch, w, h);
                    }
                }
                catch (Exception)
                {
                }

            }
            //).Start();
            return null;
        }
    }
}
