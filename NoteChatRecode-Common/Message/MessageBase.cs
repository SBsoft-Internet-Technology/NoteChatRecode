using NoteChatRecode_Common.Core.Room;
using NoteChatRecode_Common.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common.Message
{
    public abstract class MessageBase
    {
        public User sender;
        public User? receiver;
        public DateTime sendTime;
        public NoteChatRecode_Common.Core.Room.Room? room;
        public abstract string GetStringJson();
    }
}
