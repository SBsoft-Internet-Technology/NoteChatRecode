using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common.Core.User
{
    public class User
    {
        public bool Online;
        public readonly int ID;
        public string Username;
        public string Password;
        public string Email;
       
        public User(string username,string password,string email) { 
            this.ID = new Random().Next(1,114514);
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Online = false;
        }
        public string GetJsonString()
        {
            return "{\"ID\":" + ID + ",\"Username\":\"" + Username + "\",\"Password\":\"" + Password + "\",\"Email\":\"" + Email + "\"}";
        }
    }
}
