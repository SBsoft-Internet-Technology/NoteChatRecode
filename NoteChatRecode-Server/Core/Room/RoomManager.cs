using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteChatRecode_Common.Core.Room;
namespace NoteChatRecode_Server.Core.Room
{
    public class RoomManager
    {
        private List<NoteChatRecode_Common.Core.Room.Room> _rooms;
        public RoomManager()
        {
            _rooms = new List<NoteChatRecode_Common.Core.Room.Room>();
        }
        public void AddRoom(NoteChatRecode_Common.Core.Room.Room room)
        {
            _rooms.Add(room);
        }
        public void RemoveRoom(NoteChatRecode_Common.Core.Room.Room room)
        {
            _rooms.Remove(room);
        }
    }
}
