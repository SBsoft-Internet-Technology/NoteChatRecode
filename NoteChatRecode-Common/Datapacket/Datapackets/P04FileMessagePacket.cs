using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common.DataPack.Datapackets
{
    public class S04FileMessagePacket : DataPacket
    {
        public override int id { get; } = 0x04;

        public S04FileMessagePacket() { }

        public override void WriteData()
        {
            // 实现 WriteData 方法
        }

        public override void ReadData()
        {
            // 实现 ReadData 方法
        }
    }
}
