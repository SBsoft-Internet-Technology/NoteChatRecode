using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common.DataPack.Datapackets
{
    public class S00LoginRequestPacket : DataPacket
    {
        public override int id { get; } = 0x00;
        public string Username;
        public string Password;

        public S00LoginRequestPacket(string username, string password) { this.Username = username; this.Password = password; }

        public override void WriteData()
        {
            string json = "{\"Username\":\"" + Username + "\",\"Password\":\"" + Password + "\"}";
            Data = new byte[1 + Encoding.UTF8.GetByteCount(json)];
            Data[0] = (byte)id;
            
            byte[] jsonbyted = Encoding.UTF8.GetBytes(json);

            Array.Copy(jsonbyted, 0, Data, 1, jsonbyted.Length);

            foreach (byte b in Data)
            {
                Console.Write(b);
                Console.WriteLine();
            }
            
        }

        public override void ReadData()
        {

        }

    }
}
