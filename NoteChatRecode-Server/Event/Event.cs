using NoteChatRecode_Common;
using NoteChatRecode_Common.Core.User;

namespace NoteChatRecode_Server.Event
{
    public class Event
    {
        // 定义事件委托
        public delegate void ClientConnectEventHandler(object sender, ClientConnectEventArgs e);
        public delegate void ClientDisconnectEventHandler(object sender, ClientDisconnectEventArgs e);
        public delegate void ClientPacketEventHandler(object sender, ClientPacketEventArgs e);

        // 定义事件
        public event ClientConnectEventHandler ClientConnectEvent;
        public event ClientDisconnectEventHandler ClientDisconnectEvent;
        public event ClientPacketEventHandler ClientPacketEvent;

        // 触发 ClientConnectEvent
        public void OnUserConnect(User user)
        {
            ClientConnectEvent?.Invoke(this, new ClientConnectEventArgs(user));
        }

        // 触发 ClientDisconnectEvent
        public void OnUserDisconnect(User user)
        {
            ClientDisconnectEvent?.Invoke(this, new ClientDisconnectEventArgs(user));
        }

        // 触发 ClientPacketEvent
        public void OnUserPacket(User user, DataPacket packet)
        {
            ClientPacketEvent?.Invoke(this, new ClientPacketEventArgs(user, packet));
        }
    }

    // ClientConnectEventArgs 类
    public class ClientConnectEventArgs : EventArgs
    {
        public User User { get; }

        public ClientConnectEventArgs(User user)
        {
            User = user;
        }
    }

    // ClientDisconnectEventArgs 类
    public class ClientDisconnectEventArgs : EventArgs
    {
        public User User { get; }

        public ClientDisconnectEventArgs(User user)
        {
            User = user;
        }
    }

    // ClientPacketEventArgs 类
    public class ClientPacketEventArgs : EventArgs
    {
        public User User { get; }
        public DataPacket Packet { get; }

        public ClientPacketEventArgs(User user, DataPacket packet)
        {
            User = user;
            Packet = packet;
        }
    }
}
