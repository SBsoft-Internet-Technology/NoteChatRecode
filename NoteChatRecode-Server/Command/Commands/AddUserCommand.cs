using System;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Command.Commands
{
    public class AddUserCommand : Command
    {
        public AddUserCommand()
            : base("adduser", new string[] { }, async (args) => await Execute(args))
        {
        }

        private static async Task Execute(string[] args)
        {
            if (args.Length == 3)
            {
                string username = args[0];
                string password = args[1];
                string email = args[2];
                NoteChatServer.INSTANCE.userManager.RegisterNewUser(username, password, email);
                Logger.Info("User added successfully!");
            }else if (args.Length == 2)
            {
                string username = args[0];
                string password = args[1];
                NoteChatServer.INSTANCE.userManager.RegisterNewUser(username, password,"");
                Logger.Info("User added successfully!");
            }
            else
            {
                Logger.Error("Invalid arguments! Usage: /adduser <username> <password> [email]");
            }
        }
    }
}
