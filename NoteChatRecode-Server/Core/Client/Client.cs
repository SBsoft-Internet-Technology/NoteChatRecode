using NoteChatRecode_Common.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Core.Client
{
    public class Client
    {
        public Websocket.WebSocket socket;
        public NoteChatRecode_Common.Core.User.User User;
        public string IP;
        public Client(string ip)
        {

            IP = ip;

        }
        public void SendData(NoteChatRecode_Common.DataPacket dataPacket)
        {
            socket.SendPacketAsync(dataPacket);
        }
    }
}
