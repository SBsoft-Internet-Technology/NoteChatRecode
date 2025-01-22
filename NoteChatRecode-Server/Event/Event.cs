using System;
using NoteChatRecode_Common.Core.User;

using NoteChatRecode_Server.Websocket.Datapacket;


namespace NoteChatRecode_Server.Event
{
    public class Event
    {
        // 用户连接事件委托
        public delegate void UserConnectEventHandler(object sender, UserEventArgs e);
        public event UserConnectEventHandler UserConnectEvent;

        // 用户断开连接事件委托
        public delegate void UserDisconnectEventHandler(object sender, UserEventArgs e);
        public event UserDisconnectEventHandler UserDisconnectEvent;

        // 用户数据包事件委托
        public delegate void UserPacketEventHandler(object sender, UserPacketEventArgs e);
        public event UserPacketEventHandler UserPacketEvent;

        // 触发用户连接事件
        public void OnUserConnect(User user)
        {
            UserConnectEvent?.Invoke(this, new UserEventArgs(user));
        }

        // 触发用户断开连接事件
        public void OnUserDisconnect(User user)
        {
            UserDisconnectEvent?.Invoke(this, new UserEventArgs(user));
        }

        // 触发用户数据包事件
        public void OnUserPacket(User user, DataPacket packet)
        {
            UserPacketEvent?.Invoke(this, new UserPacketEventArgs(user, packet));
        }
    }

    // 用户事件参数类
    public class UserEventArgs : EventArgs
    {
        public User User { get; }

        public UserEventArgs(User user)
        {
            User = user;
        }
    }

    // 用户数据包事件参数类
    public class UserPacketEventArgs : EventArgs
    {
        public User User { get; }
        public DataPacket Packet { get; }

        public UserPacketEventArgs(User user, DataPacket packet)
        {
            User = user;
            Packet = packet;
        }
    }
}
