using System;
using System.Text;
using System.Text.Json;

namespace NoteChatRecode_Common.Datapacket.Datapackets
{
    public class C114PingPacket : DataPacket
    {
        public string name;
        public string desp;
        public long servertime;
        public override int id => 114;

        public C114PingPacket()
        {
        }

        public C114PingPacket(string name, string desp, long servertime)
        {
            this.name = name;
            this.desp = desp;
            this.servertime = servertime;
        }

        public override void ReadData()
        {
            // 读取数据时，跳过第一个字节（数据包 ID）
            string json = Encoding.UTF8.GetString(Data, 1, Data.Length - 1);
            var packet = JsonSerializer.Deserialize<C114PingPacket>(json);
            name = packet.name;
            desp = packet.desp;
            servertime = packet.servertime;
        }

        public override void WriteData()
        {
            // 将对象序列化为 JSON
            string json = JsonSerializer.Serialize(this);
            byte[] jsonData = Encoding.UTF8.GetBytes(json);

            // 创建数据包，包含第一个字节为数据包 ID
            Data = new byte[jsonData.Length + 1];
            Data[0] = (byte)id;
            Array.Copy(jsonData, 0, Data, 1, jsonData.Length);
        }
    }
}
