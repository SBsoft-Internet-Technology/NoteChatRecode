using System;
using System.Threading.Tasks;

namespace NoteChatRecode_Server.Command
{
    public abstract class Command
    {
        public string Name { get; }
        public string[] Aliases { get; }
        private readonly Func<string[], Task> _execute;

        protected Command(string name, string[] aliases, Func<string[], Task> execute)
        {
            Name = name;
            Aliases = aliases ?? Array.Empty<string>();
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public async Task Execute(string[] args)
        {
            await _execute(args);
        }
    }
}
