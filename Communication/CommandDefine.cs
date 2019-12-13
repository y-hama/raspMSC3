using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class CommandDefine
    {
        public delegate Command CommandFunction(Command command);
        public delegate void ResponseRecievedHandler(Command command);

        public enum MessageState
        {
            Message,
            Request,
            Response,
        }

        public string ID { get; private set; }

        public int ParameterCount { get; private set; }
        public CommandFunction Function { get; set; }

        private CommandDefine() { }

        public static CommandDefine CreateDefine(string id, int paramcount, CommandFunction function)
        {
            CommandDefine res = new CommandDefine();
            res.ID = id;
            res.ParameterCount = paramcount;
            res.Function = function;
            return res;
        }

        public static bool Compare(CommandDefine def, Command target)
        {
            return def.ID == target.ID && def.ParameterCount <= target.ParameterCount;
        }
    }
}
