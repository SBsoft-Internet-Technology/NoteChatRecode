using NoteChatRecode_Common.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server
{
    public class Client
    {
        public Websocket.WebSocket socket;
        public User User;
        public string IP;
        public Client(string ip)
        {
            
            IP = ip;
            
        }
    }
}
