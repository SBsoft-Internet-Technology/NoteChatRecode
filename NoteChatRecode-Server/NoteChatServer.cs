using NoteChatRecode_Server.Command;
using NoteChatRecode_Server.Core.Room;
using NoteChatRecode_Server.Core.User;
using NoteChatRecode_Server.Websocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server
{
    public class NoteChatServer
    { public static string VERSION = "1.0.0";
        public static NoteChatServer INSTANCE;
        public string serverName;
        public string serverIP;
        public string serverPort;
        public string serverPassword;
        public string serverDescription;
        public string serverOwner;
        public RoomManager roomManager;
        public UserManager userManager;
        public CommandManager commandManager;
        public WebSocketServer server;
        public NoteChatServer(string serverName,string serverIP,string serverPort) {
            this.serverName = serverName;
            this.serverIP = serverIP;
            this.serverPort = serverPort;
            this.serverPassword = "";
            this.serverDescription = "A NoteChat Server base on NoteChat Server " + VERSION;
            this.userManager = new UserManager();
            this.roomManager = new RoomManager();
            commandManager = new CommandManager();
            server = new WebSocketServer($"http://{serverIP}:{serverPort}/");
            INSTANCE = this;

        }
    }
}
