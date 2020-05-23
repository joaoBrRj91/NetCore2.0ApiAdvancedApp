using System.Collections.Generic;

namespace JohnStore.Shared.Commands
{
    public interface ICommandResult
    {
         bool Success { get; }
         IDictionary<string, string> Notifications { get; set; }
    }
}