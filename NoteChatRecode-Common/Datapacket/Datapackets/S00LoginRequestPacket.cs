using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NoteChatRecode_Common.DataPack.Datapackets
{
    public class S00LoginRequestPacket : DataPacket
    {
        public override int id { get; } = 0x00;
        public string Username;
        public string Password;
        public S00LoginRequestPacket() { }
        public S00LoginRequestPacket(string username, string password) { this.Username = username; this.Password = password; }

        public override void WriteData()
        {
            string json = "{\"Username\":\"" + Username + "\",\"Password\":\"" + Password + "\"}";
            Data = new byte[1 + Encoding.UTF8.GetByteCount(json)];
            Data[0] = (byte)id;
            
            byte[] jsonbyted = Encoding.UTF8.GetBytes(json);

            Array.Copy(jsonbyted, 0, Data, 1, jsonbyted.Length);

            /*foreach (byte b in Data)
            {
                Console.Write(b);
                Console.WriteLine();
            }*/
        }

        public override void ReadData()
        {
            int packetId = Data[0];
            if (packetId != id)
            {
                return;
            }
            string json = Encoding.UTF8.GetString(Data, 1, Data.Length - 1);
            Username = json.Split(',')[0].Split(':')[1].Replace("\"", "");
            Password = json.Split(',')[1].Split(':')[1].Replace("\"", "");
        }
        

    }
}
