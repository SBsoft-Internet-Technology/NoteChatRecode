using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Websocket.Datapacket.Datapackets
{
    public class S07LoginResponsePacket : DataPacket
    {
        public S07LoginResponsePacket() {  }

        public override int id { get; } = 0x07;

        public override void ReadData()
        {
            
        }

        public override void WriteData()
        {
            
        }
    }
}
