using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Client
{
    public class NoteChat
    {
        public static NoteChat INSTANCE;
        public NoteChat(string serverIP,int port,string username,string password)
        {
            INSTANCE = this;

        }
        public string serverIP = "";
        public int serverPort = 0;
        public string username = "";
        public string password = "";
        public string nickname = "";
        public string status = "";
        public string avatar = "";
        public string message = "";
        public string chatWith = "";
        public int roomID = 0;
        public string roomName = "";
        public string roomPassword = "";
        public RoomType roomType = RoomType.Private;
        public string roomOwner = "";
        
    }
    public enum RoomType
    {
        Public,
        Private
    }

}
