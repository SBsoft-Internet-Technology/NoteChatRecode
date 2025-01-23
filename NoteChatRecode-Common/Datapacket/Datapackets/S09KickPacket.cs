using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common.Datapacket.Datapackets
{
    public class S09KickPacket : DataPacket
    {
        public string Reason;
        public override int id => 9;
        public S09KickPacket()
        {

        }
        public S09KickPacket(string reason)
        {
            Reason = reason;
        }
        public override void ReadData()
        {
            Array.Copy(Data, 1, Data, 0, Data.Length - 1);
            Reason = Encoding.UTF8.GetString(Data);
        }

        public override void WriteData()
        {
            Data = new byte[1 + Encoding.UTF8.GetByteCount(Reason)];
            Data[0] = (byte)id;
            byte[] jsonbyted = Encoding.UTF8.GetBytes(Reason);
            Array.Copy(jsonbyted, 0, Data, 1, jsonbyted.Length);

        }
    }
}
