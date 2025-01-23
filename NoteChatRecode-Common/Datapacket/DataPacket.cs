using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common
{
    public abstract class DataPacket
    {
        public byte[] Data;
        public abstract int id { get; }
        public abstract void WriteData();
        public abstract void ReadData();
        
    }
}
