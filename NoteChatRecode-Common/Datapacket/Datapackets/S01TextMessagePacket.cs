using NoteChatRecode_Common.Core.User;
using NoteChatRecode_Common.Message.Messages;
using System.Text;
using System.Text.Json;

namespace NoteChatRecode_Common.Datapacket.Datapackets
{
    public class S01TextMessagePacket : DataPacket
    {
        public User fromUser;
        public User toUser;
        private TextMessage textMessage;
        public override int id { get; } = 0x01;

        public S01TextMessagePacket() { }

        public S01TextMessagePacket(User fromUser, User toUser, TextMessage textMessage)
        {
            this.fromUser = fromUser;
            this.toUser = toUser;
            this.textMessage = textMessage;
        }

        public override void WriteData()
        {
            var packetData = new
            {
                fromUser = fromUser.GetJsonString(),
                toUser = toUser.GetJsonString(),
                textMessage = textMessage.GetStringJson()
            };

            string jsonString = JsonSerializer.Serialize(packetData);

            // 计算总长度
            int totalLength = 1 + Encoding.UTF8.GetByteCount(jsonString);

            // 创建数据数组
            Data = new byte[totalLength];

            // 设置数据包 ID
            Data[0] = (byte)id;

            // 将 jsonString 写入数据数组
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
            Array.Copy(jsonBytes, 0, Data, 1, jsonBytes.Length);
        }

        public override void ReadData()
        {
            // 解析数据包 ID
            int packetId = Data[0];
            if (packetId != id)
            {
                return;
            }

            // 解析 JSON 数据
            string jsonString = Encoding.UTF8.GetString(Data, 1, Data.Length - 1);
            var packetData = JsonSerializer.Deserialize<PacketData>(jsonString);

            fromUser = JsonSerializer.Deserialize<User>(packetData.fromUser);
            toUser = JsonSerializer.Deserialize<User>(packetData.toUser);
            textMessage = JsonSerializer.Deserialize<TextMessage>(packetData.textMessage);
        }

        

        private class PacketData
        {
            public string fromUser { get; set; }
            public string toUser { get; set; }
            public string textMessage { get; set; }
        }
    }
}
