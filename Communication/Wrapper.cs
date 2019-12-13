using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Communication
{
    public abstract class Wrapper
    {
        #region Wrapper
        #region Property
        protected const char MOFCHAR = '\n';

        public static bool Terminate { get; set; }
        public bool IsConnected { get; protected set; } = false;

        protected TcpListener listener { get; set; }
        protected TcpClient client { get; set; }

        private object __sndlock = new object();
        private object __reclock = new object();
        protected NetworkStream ns { get; set; }


        public static Encoding Encorde { get; set; } = Encoding.UTF8;

        protected IPAddress sourceIPAddress { get; set; }
        protected IPAddress distinationIPAddress { get; set; }

        protected int sendPort { get; set; }
        protected int recPort { get; set; }
        #endregion

        #region Event

        public delegate void DataRecievedEventHandler(Command cmd);
        protected DataRecievedEventHandler DataRecievedEvent { get; set; } = null;
        /// <summary>
        /// 受け取った生データ
        /// </summary>
        public event DataRecievedEventHandler DataRecieved
        {
            add { DataRecievedEvent += value; }
            remove { DataRecievedEvent -= value; }
        }

        /// <summary>
        /// 接続完了
        /// </summary>
        public delegate void ConnectedEventHandler();
        protected ConnectedEventHandler ConnectedEvent { get; set; } = null;
        public event ConnectedEventHandler Connected
        {
            add { ConnectedEvent += value; }
            remove { ConnectedEvent -= value; }
        }
        #endregion

        private object __reqcmdlstlock = new object();
        private List<Command> RequestCommandList { get; set; } = new List<Command>();

        protected delegate void TaskFunction();
        protected abstract TaskFunction Function { get; }

        public void Initialize(string sourceaddress, string destinationaddress, int sendport, int recport, bool mthread = true)
        {
            CreateCommonCommandTable();

            sourceIPAddress = IPAddress.Parse(sourceaddress);
            distinationIPAddress = IPAddress.Parse(destinationaddress);
            sendPort = sendport;
            recPort = recport;


            if (!mthread)
            {
                Function();
            }
            else
            {
                new Task(() => { Function(); }).Start();
            }
        }

        protected void Close()
        {
            ns.Close();
            ns = null;
            client.Close();
            if (listener != null)
            {
                listener.Stop();
            }
            Display.Console.WriteLine(DisplayMode.CommunicationState, "Disconnected.");
        }

        public void Send(Command cmd)
        {
            if (ns != null)
            {
                try
                {
                    if (cmd.MessageState == CommandDefine.MessageState.Request)
                    {
                        lock (__reqcmdlstlock)
                        {
                            RequestCommandList.Add(cmd);
                        }
                    }
                    cmd.SendTime = DateTime.Now;
                    var sendBytes = cmd.ToBuffer();
                    sendBytes.Add(Convert.ToByte(MOFCHAR));
                    lock (__sndlock)
                    {
                        ns.Write(sendBytes.ToArray(), 0, sendBytes.Count);
                    }
                    Display.Console.WriteLine(DisplayMode.CommunicationLatestSendMessage, cmd.GetString());
                }
                catch (Exception)
                {
                }
            }
        }

        protected void ConnectedProcess()
        {
            ns = client.GetStream();
            ConnectedEvent?.Invoke();
            Display.Console.WriteLine(DisplayMode.CommunicationError, "");
        }

        protected bool RecieveProcess()
        {
            IsConnected = true;
            int resSize = 0;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            byte[] resBytes = new byte[120000];
            try
            {
                do
                {
                    try
                    {
                        //lock (__reclock)
                        {
                            resSize = ns.Read(resBytes, 0, resBytes.Length);
                        }
                    }
                    catch (Exception)
                    {
                        IsConnected = false;
                    }
                    if (resSize == 0)
                    {
                        IsConnected = false;
                        break;
                    }
                    ms.Write(resBytes, 0, resSize);
                } while (ns.DataAvailable || resBytes[resSize - 1] != MOFCHAR);
            }
            catch (Exception)
            {
                IsConnected = false;
            }

            if (IsConnected)
            {
                try
                {
                    if (ms.Length > 1)
                    {
                        var btmpbuf = ms.GetBuffer();
                        byte[] buf = new byte[ms.Length - 1];
                        Array.Copy(btmpbuf, buf, ms.Length - 1);
                        ms.Close();
                        GetBuffer(buf);
                    }
                }
                catch (Exception)
                {
                }
            }
            return IsConnected;
        }

        private void GetBuffer(byte[] buf)
        {
            var reccmd = new Command(buf);
            if (reccmd.MessageState == CommandDefine.MessageState.Response)
            {
                List<Command> sndcmds = null;
                lock (__reqcmdlstlock)
                {
                    sndcmds = RequestCommandList.FindAll(x => x.Serial == reccmd.Serial);
                    RequestCommandList.RemoveAll(x => sndcmds.Contains(x));
                }
                if (sndcmds != null && sndcmds.Count > 0)
                {
                    foreach (var item in sndcmds)
                    {
                        item.ResponseRecievedEvent?.Invoke(item);
                    }
                }
            }
            else
            {
                var defcmds = CommandList.FindAll(x => CommandDefine.Compare(x, reccmd));
                var defcmd = defcmds != null && defcmds.Count > 0 ? defcmds[0] : null;
                if (defcmd == null)
                {
                    Display.Console.WriteLine(DisplayMode.CommunicationError, "{0}(unknown message)", reccmd.GetString());
                }
                else
                {
                    if (DataRecievedEvent != null)
                    {
                        DataRecievedEvent(reccmd);
                    }
                    Parse(reccmd, defcmd);
                }
            }
        }
        #endregion

        #region CommandParser
        private List<CommandDefine> CommandList { get; set; } = new List<CommandDefine>();

        protected abstract void CreateCommandTable();

        private void CreateCommonCommandTable()
        {
            AddCommand(CommandDefine.CreateDefine("k/a", 0, KeepArriveCommend));
            CreateCommandTable();
        }

        #region CommonCommand
        private static Communication.Command KeepArriveCommend(Command command)
        {
            return Command.Create("k/a", null);
        }

        #endregion

        protected void AddCommand(CommandDefine command)
        {
            if (CommandList.Find(x => x.ID == command.ID) == null)
            {
                CommandList.Add(command);
            }
        }

        private void Parse(Command reccmd, CommandDefine def)
        {
            if (def != null)
            {
                if (def.Function != null)
                {
                    new Task(() =>
                    {
                        var result = def.Function(reccmd);
                        if (result != null)
                        {
                            Send(result);
                        }
                        if (reccmd.MessageState == CommandDefine.MessageState.Request)
                        {
                            var response = Command.Response(reccmd);
                            Send(response);
                        }
                    }).Start();
                }
            }
        }
        #endregion
    }
}
