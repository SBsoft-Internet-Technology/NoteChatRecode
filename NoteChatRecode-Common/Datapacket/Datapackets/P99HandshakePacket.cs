using NoteChatRecode_Common.Datapacket;
using System.Text.Json;

namespace NoteChatRecode_Common.DataPack.Datapackets
{
    public class P99HandShakePacket : DataPacket
    {
        public override int id => 99;
        public DateTime ClientTime { get; set; }
        public DateTime ServerTime { get; set; }

        public override void WriteData()
        {
            var jsonData = JsonSerializer.Serialize(this);
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
            Data = new byte[jsonBytes.Length + 1];
            Data[0] = (byte)id; // 写入数据包 ID
            Array.Copy(jsonBytes, 0, Data, 1, jsonBytes.Length);
        }

        public override void ReadData()
        {
            if (Data[0] != (byte)id)
            {
                throw new InvalidOperationException("Invalid packet ID.");
            }

            var jsonData = System.Text.Encoding.UTF8.GetString(Data, 1, Data.Length - 1);
            var packet = JsonSerializer.Deserialize<P99HandShakePacket>(jsonData);
            if (packet != null)
            {
                ClientTime = packet.ClientTime;
                ServerTime = packet.ServerTime;
            }
            else
            {
                throw new EndOfStreamException("Failed to deserialize JSON data.");
            }
        }
    }
}
