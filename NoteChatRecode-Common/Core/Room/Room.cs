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
        public List<User.User> Users;
        public Room(string name,string de,string password = "") {
            this.Name = name;
            this.Description = de;
            this.Password = password;
            this.Users = new List<User.User>();

        }
        public void AddUser(User.User user)
        {
            Users.Add(user);
        }

    }
}
