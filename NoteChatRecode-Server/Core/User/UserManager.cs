using NoteChatRecode_Common.Core.User;
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
        public int GetTotalCountUsers()
        {
            return _users.Count;
        }
        public List<NoteChatRecode_Common.Core.User.User> GetAllUser()
        {
            return _users.Values.ToList();
        }
        public NoteChatRecode_Common.Core.User.User GetUserByName(string username)
        {
            foreach (var user in _users)
            {
                if (user.Value.Username == username)
                {
                    return user.Value;
                }
            }
            
            return null;
        }
        public NoteChatRecode_Common.Core.User.User GetUser(string username,string password)
        {
            Logger.Debug(username + " " + password);
            foreach(var user in _users)
            {
                if (user.Value.Username == username && user.Value.Password == password)
                {
                    return user.Value;
                }
            }
            return null;
        }

    }
}
