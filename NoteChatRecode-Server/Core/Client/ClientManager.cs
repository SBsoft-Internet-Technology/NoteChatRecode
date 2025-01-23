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
        public void RemoveClient(Client client)
        {
            Clients.Remove(client);
        }
    }
}
