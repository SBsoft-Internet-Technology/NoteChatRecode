using NoteChatRecode_Common.DataPack.Datapackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Core.User
{
    public class UserManager
    {
        private Dictionary<string, NoteChatRecode_Common.Core.User.User> _users;
        public UserManager()
        {
            _users = new Dictionary<string, NoteChatRecode_Common.Core.User.User>();
        }
        public void RegisterNewUser(string username,string password,string email)
        {
            _users.Add(username,new NoteChatRecode_Common.Core.User.User(username,password,email));
        }
        public int GetTotalUsers()
        {
            return _users.Count;
        }
        public NoteChatRecode_Common.Core.User.User GetUser(string username,string password)
        {
            foreach (var user in _users)
            {
                if (user.Value.Username == username && user.Value.Password == password)
                {
                    return user.Value;
                }
            }
            new S06InvaildOperation("Invalid Username or Password").WriteData();
            return null;
        }
    }
}
