using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Core.Client
{
    public class ClientManager
    {
        private List<Client> Clients;
        public ClientManager()
        {
            Clients = new List<Client>();
        }
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }
        public Client GetClient(string username)
        {
            return Clients.Find(client => client.User.Username == username);
        }
        public void RemoveClient(Client client)
        {
            if (Clients.Count == 0) return;
            if (Clients.Contains(client))
            {
                
                Clients.Remove(client);
            }
        }
        }
}
