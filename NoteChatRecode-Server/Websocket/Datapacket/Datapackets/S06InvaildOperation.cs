using NoteChatRecode_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Websocket.Datapacket.Datapackets
{
    public class S06InvaildOperation : DataPacket
    {
        public override int id { get; } = 0x06;
        public override void WriteData()
        {
            // 实现 WriteData 方法
        }
        public S06InvaildOperation(string message) { }
        public override void ReadData()
        {
            // 实现 ReadData 方法
        }

    }
}
