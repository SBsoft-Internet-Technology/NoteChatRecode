using NoteChatRecode_Server.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Command
{
    public class CommandManager
    {
        private readonly Dictionary<string, Command> _commands;

        public CommandManager()
        {
            _commands = new Dictionary<string, Command>(StringComparer.OrdinalIgnoreCase);
            RegisterCommand(new HelpCommand());
            RegisterCommand(new AddUserCommand());
            RegisterCommand(new UserListCommand());
        }

        public void RegisterCommand(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            // Register the command and its aliases
            if (!_commands.ContainsKey(command.Name))
                _commands[command.Name] = command;

            foreach (var alias in command.Aliases)
            {
                if (!_commands.ContainsKey(alias))
                    _commands[alias] = command;
            }
        }

        public IEnumerable<Command> GetCommands()
        {
            return _commands.Values.Distinct();
        }

        public async Task ExecuteCommandAsync(string input)
        {
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return;

            var commandName = parts[0];
            var args = parts.Length > 1 ? parts[1..] : Array.Empty<string>();

            if (_commands.TryGetValue(commandName, out var command))
            {
                await command.Execute(args);
            }
            else
            {
                Logger.Error($"Unknown command: {commandName}");
            }
        }
    }
}
