using System;
using System.Collections.Generic;

namespace NoteChatRecode_Server.Websocket.Datapacket.Datapackets
{
    public class DataPacketManager
    {
        private readonly Dictionary<int, DataPacket> _dataPackets;

        public DataPacketManager()
        {
            
        }

        public bool TryGetPacket(int id, out DataPacket packet)
        {
            return _dataPackets.TryGetValue(id, out packet);
        }
    }
}
