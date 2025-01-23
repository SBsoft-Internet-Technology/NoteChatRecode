using System;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Command.Commands
{
    public class HelpCommand : Command
    {
        public HelpCommand() : base("help", new[] { "h" }, async (args) =>
        {
            Logger.Info("Available commands:");
            foreach (var command in NoteChatServer.INSTANCE.commandManager.GetCommands())
            {
                Logger.Info($"- {command.Name} ({string.Join(", ", command.Aliases)})");
            }
            await Task.CompletedTask;
        })
        {
        }
    }
}
