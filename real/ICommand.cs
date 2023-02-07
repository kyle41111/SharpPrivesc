using System.Collections.Generic;

namespace Privesc.Commands
{
    public interface ICommand
    {
        void Execute(Dictionary<string, string> arguments);
    }
}
