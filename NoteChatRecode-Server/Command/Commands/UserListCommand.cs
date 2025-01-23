using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Command.Commands
{
    public class UserListCommand : Command
    {
        public UserListCommand() : base("userlist", new string[] {}, async (args) => await execute(args))
        {
        }
        private static async Task execute(string[] args)
        {
            Logger.Info("Users:");
            foreach (var client in NoteChatServer.INSTANCE.userManager.GetAllUser())
            {
                Logger.Info($"- {client.Username}");
            }
            await Task.CompletedTask;
        }
    }
}
