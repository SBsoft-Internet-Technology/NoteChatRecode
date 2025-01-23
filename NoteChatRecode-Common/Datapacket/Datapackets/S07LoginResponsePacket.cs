using NoteChatRecode_Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common.Websocket.Datapacket.Datapackets
{
    public class S07LoginResponsePacket : DataPacket
    {
        public bool Success;
        public string Message;
        public S07LoginResponsePacket() { 
            
        }
        public S07LoginResponsePacket(string message,bool su)
        {
            Message = message;
            Success = su;

        }

        public override int id { get; } = 0x07;

        public override void ReadData()
        {
            int packetId = Data[0];
            if (packetId != id)
            {
                return;
            }
            
            string json = Encoding.UTF8.GetString(Data, 1, Data.Length - 1);
            
            Message = json.Split(',')[0].Split(':')[1].Replace("\"", "");
            Debug.WriteLine(json.Split(',')[1].Split(':')[1].Replace("\"", "").ToLower());
            Success = bool.Parse(json.Split(',')[1].Split(':')[1].Replace("\"", "").ToLower().Replace("}",""));
            Debug.WriteLine(Success);
        }

        public override void WriteData()
        {
            string json = "{\"Message\":\"" + Message + "\",\"Success\":\"" + Success + "\"}";
            Data = new byte[1 + Encoding.UTF8.GetByteCount(json)];
            Data[0] = (byte)id;

            byte[] jsonbyted = Encoding.UTF8.GetBytes(json);

            Array.Copy(jsonbyted, 0, Data, 1, jsonbyted.Length);
            Console.WriteLine(json);
        }
    }
}
