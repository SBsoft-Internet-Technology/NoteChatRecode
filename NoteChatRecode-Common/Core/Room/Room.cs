using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common.Core.Room
{
    public class Room
    {
        public string Name;
        public string Description;
        public string Password;
        public RoomType Type;
        public List<User.User> Users;
        public Room(string name,string de,RoomType type,string password = "") {
            this.Name = name;
            this.Description = de;
            this.Password = password;
            this.Users = new List<User.User>();
            this.Type = type;

        }
        public void AddUser(User.User user)
        {
            Users.Add(user);
        }

    }
    public enum RoomType
    {
        Public,
        Private
    }
}
