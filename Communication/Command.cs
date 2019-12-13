using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class Command
    {
        #region Property
        private const char SPLITTER = ';';

        private static long serialseed { get; set; } = 0;
        private long serial { get; set; } = -1;
        public long Serial { get { return serial; } }
        public DateTime SendTime { get; set; } = DateTime.Now;

        public string ID { get; private set; } = string.Empty;

        private int prmcnt { get; set; } = -1;
        public int ParameterCount { get { return prmcnt >= 0 ? prmcnt : Parameter.Count; } private set { prmcnt = value; } }
        public List<string> Parameter { get; private set; } = new List<string>();
        public byte[] Data { get; private set; } = null;

        public CommandDefine.MessageState MessageState { get; set; } = CommandDefine.MessageState.Message;
        public CommandDefine.ResponseRecievedHandler ResponseRecievedEvent { get; set; }
        public event CommandDefine.ResponseRecievedHandler ResponseRecieved
        {
            add { ResponseRecievedEvent += value; }
            remove { ResponseRecievedEvent -= value; }
        }
        #endregion

        public string GetString()
        {
            return ID + "(s/n:" + serial.ToString() + ")(pn:" + ParameterCount.ToString() + ") -> " + SendTime.ToLongTimeString() + "'" + SendTime.Millisecond.ToString();
        }

        public List<byte> ToBuffer()
        {
            List<byte> ret = new List<byte>();

            byte headCnt = (byte)(/* len */1 + /* msgst */1 + /* serial */1 +  /* id */1 + Parameter.Count);
            ret.AddRange(new List<byte>(new byte[] { headCnt }));
            ret.AddRange(new List<byte>(Wrapper.Encorde.GetBytes(SPLITTER.ToString())));

            ret.AddRange(new List<byte>(Wrapper.Encorde.GetBytes(((int)MessageState).ToString())));
            ret.AddRange(new List<byte>(Wrapper.Encorde.GetBytes(SPLITTER.ToString())));

            ret.AddRange(new List<byte>(Wrapper.Encorde.GetBytes(Serial.ToString())));
            ret.AddRange(new List<byte>(Wrapper.Encorde.GetBytes(SPLITTER.ToString())));

            ret.AddRange(new List<byte>(Wrapper.Encorde.GetBytes(ID)));
            ret.AddRange(new List<byte>(Wrapper.Encorde.GetBytes(SPLITTER.ToString())));

            for (int i = 0; i < Parameter.Count; i++)
            {
                ret.AddRange(new List<byte>(Wrapper.Encorde.GetBytes(Parameter[i])));
                ret.AddRange(new List<byte>(Wrapper.Encorde.GetBytes(SPLITTER.ToString())));
            }

            if (Data != null)
            {
                ret.AddRange(new List<byte>(Data));
            }

            return ret;
        }

        #region Constructor
        private Command() { }
        private Command(string id, byte[] data, params object[] param)
        {
            serialseed++; if (serialseed > int.MaxValue) { serialseed = 1; }
            serial = serialseed;
            ID = id;
            Parameter = new List<string>(param == null ? new string[0] : param.Select(x => Convert.ToString(x)));
            Data = data == null ? null : (byte[])data.Clone();
        }
        public Command(byte[] buf)
        {
            int headlen;
            List<byte[]> segment = new List<byte[]>();
            #region bufをデータ領域に分割
            int idx = 0;
            byte[] dist;
            CutBuffer(buf, out dist, idx, SPLITTER, out idx);

            // ヘッダ長確定
            headlen = dist[0];

            idx = 0;    // 一旦seek位置を巻き戻す
            bool existsData = false;
            while (segment.Count != headlen)
            {
                existsData = CutBuffer(buf, out dist, idx, SPLITTER, out idx);
                segment.Add(dist);
            }
            if (existsData)
            {
                CutBuffer(buf, out dist, idx);
                segment.Add(dist);
            }
            #endregion
            // segment[0] : ヘッダ長( = headlen)
            // segment[1] : reqres
            // segment[2] : serial
            // segment[3] : ID
            // segment[4~len-4] : パラメータ
            // segment[len-1] : データ

            MessageState = (CommandDefine.MessageState)Enum.ToObject(typeof(CommandDefine.MessageState), Convert.ToInt64(Wrapper.Encorde.GetString(segment[1], 0, (int)segment[1].Length).TrimEnd('\n')));
            serial = Convert.ToInt64(Wrapper.Encorde.GetString(segment[2], 0, (int)segment[2].Length).TrimEnd('\n'));
            ID = Wrapper.Encorde.GetString(segment[3], 0, (int)segment[3].Length).TrimEnd('\n');
            for (int i = 4; i < headlen; i++)
            {
                Parameter.Add(Wrapper.Encorde.GetString(segment[i], 0, (int)segment[i].Length).TrimEnd('\n'));
            }
            if (headlen < segment.Count)
            {
                Data = (byte[])segment[segment.Count - 1].Clone();
            }

            //string resMsg = Wrapper.Encorde.GetString(buf, 0, (int)buf.Length).TrimEnd('\n');
        }
        #endregion

        #region PrivateMethod
        private bool CutBuffer(byte[] source, out byte[] dist, int startindex, char symbol, out int endindex)
        {
            int idx = 0;
            List<byte> res = new List<byte>();
            bool ret = false;
            while ((ret = !(source.Length > startindex + idx && source[startindex + idx] != symbol)) == false)
            {
                res.Add(source[startindex + (idx++)]);
            }
            endindex = startindex + idx + 1;
            if (endindex == source.Length)
            {
                ret = false;
            }
            dist = res.ToArray();
            return ret;
        }

        public void CutBuffer(byte[] source, out byte[] dist, int startindex)
        {
            dist = new byte[source.Length - startindex];
            Array.Copy(source, startindex, dist, 0, dist.Length);
        }
        #endregion

        public static Command CreateWithResponse(string id, CommandDefine.ResponseRecievedHandler responsehandler, byte[] data, params object[] param)
        {
            return new Communication.Command(id, data, param)
            {
                MessageState = CommandDefine.MessageState.Request,
                ResponseRecievedEvent = responsehandler
            };
        }

        public static Command Create(string id, byte[] data, params object[] param)
        {
            return new Communication.Command(id, data, param);
        }

        public static Command Response(Command cmd)
        {
            Command res = new Command();
            res.serial = cmd.serial;
            res.ID = cmd.ID;
            res.MessageState = CommandDefine.MessageState.Response;
            res.Parameter = res.Parameter;
            res.Data = null;
            return res;
        }
    }
}
