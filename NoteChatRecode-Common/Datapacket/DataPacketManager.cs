using NoteChatRecode_Common.DataPack.Datapackets;
using NoteChatRecode_Common.Datapacket.Datapackets;
using System;
using System.Collections.Generic;

namespace NoteChatRecode_Common.Websocket.Datapacket.Datapackets
{
    public class DataPacketManager
    {
        private readonly Dictionary<int, Type> _dataPacketTypes;

        public DataPacketManager()
        {
            _dataPacketTypes = new Dictionary<int, Type>();
            RegisterPackets();
        }

        private void RegisterPackets()
        {
            RegisterPacket<S07LoginResponsePacket>();
            RegisterPacket<C08LoginRequestPacket>();
            RegisterPacket<P01TextMessagePacket>();
            RegisterPacket<P99HandShakePacket>();
            RegisterPacket<C114PingPacket>();
            /*RegisterPacket<S02ImageMessagePacket>();
            RegisterPacket<S03RichMessagePacket>();
            RegisterPacket<S04FileMessagePacket>();*/
        }

        public void RegisterPacket<T>() where T : DataPacket, new()
        {
            var packet = new T();
            _dataPacketTypes[packet.id] = typeof(T);
        }

        public bool TryGetPacket(int id, out DataPacket packet)
        {
            packet = null;
            if (_dataPacketTypes.TryGetValue(id, out var type))
            {
                packet = (DataPacket)Activator.CreateInstance(type);
                return true;
            }
            return false;
        }
    }
}
