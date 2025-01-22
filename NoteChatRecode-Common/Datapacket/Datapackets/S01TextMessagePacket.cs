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

        public S01TextMessagePacket(User fromUser, User toUser, TextMessage textMessage)
        {
            this.fromUser = fromUser;
            this.toUser = toUser;
            this.textMessage = textMessage;
        }

        public override void WriteData()
        {
            string fromUserJson = fromUser.GetJsonString();
            string toUserJson = toUser.GetJsonString();
            string textMessageJson = textMessage.GetStringJson();

            // 计算总长度
            int totalLength = 1 + Encoding.UTF8.GetByteCount(fromUserJson) + Encoding.UTF8.GetByteCount(toUserJson) + Encoding.UTF8.GetByteCount(textMessageJson);

            // 创建数据数组
            Data = new byte[totalLength];

            // 设置数据包 ID
            Data[0] = (byte)id;

            // 将 fromUserJson 写入数据数组
            byte[] fromUserBytes = Encoding.UTF8.GetBytes(fromUserJson);
            Array.Copy(fromUserBytes, 0, Data, 1, fromUserBytes.Length);

            // 将 toUserJson 写入数据数组
            byte[] toUserBytes = Encoding.UTF8.GetBytes(toUserJson);
            Array.Copy(toUserBytes, 0, Data, 1 + fromUserBytes.Length, toUserBytes.Length);

            // 将 textMessageJson 写入数据数组
            byte[] textMessageBytes = Encoding.UTF8.GetBytes(textMessageJson);
            Array.Copy(textMessageBytes, 0, Data, 1 + fromUserBytes.Length + toUserBytes.Length, textMessageBytes.Length);
        }

        public override void ReadData()
        {
            // 解析数据包 ID
            int packetId = Data[0];
            if (packetId != id)
            {
                throw new InvalidOperationException("Invalid packet ID");
            }

            // 解析 fromUserJson
            int fromUserLength = Array.IndexOf(Data, (byte)0, 1) - 1;
            string fromUserJson = Encoding.UTF8.GetString(Data, 1, fromUserLength);
            fromUser = JsonSerializer.Deserialize<User>(fromUserJson);

            // 解析 toUserJson
            int toUserStartIndex = 1 + fromUserLength + 1;
            int toUserLength = Array.IndexOf(Data, (byte)0, toUserStartIndex) - toUserStartIndex;
            string toUserJson = Encoding.UTF8.GetString(Data, toUserStartIndex, toUserLength);
            toUser = JsonSerializer.Deserialize<User>(toUserJson);

            // 解析 textMessageJson
            int textMessageStartIndex = toUserStartIndex + toUserLength + 1;
            int textMessageLength = Data.Length - textMessageStartIndex;
            string textMessageJson = Encoding.UTF8.GetString(Data, textMessageStartIndex, textMessageLength);
            textMessage = JsonSerializer.Deserialize<TextMessage>(textMessageJson);
        }
    }
}
