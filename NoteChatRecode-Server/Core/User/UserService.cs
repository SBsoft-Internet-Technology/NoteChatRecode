using NoteChatRecode_Common.Websocket.Datapacket.Datapackets;
using NoteChatRecode_Server;
using NoteChatRecode_Server.Event;
using NoteChatRecode_Server.Websocket;
using NoteChatRecode_Server.Websocket.Datapacket.Datapackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common.Core.User
{
    
    public class UserService
    {
        
        public UserService()
        {
            
            NoteChatServer.INSTANCE.EventManager.ClientConnectEvent += OnClientConnect;
            
           
        }   
        private void OnClientConnect(object sender, ClientConnectEventArgs e)
        {
            Logger.Info("User connected");
            if (null != NoteChatServer.INSTANCE.userManager.GetUser(e.User.Username, e.User.Password))
            {
                e.Client.SendData(new S07LoginResponsePacket("Welcome", true));
            }
            else { e.Client.SendData(new S07LoginResponsePacket("操你妈用户不存在或者密码错了", false)); }
        }
        

        
    }
}
