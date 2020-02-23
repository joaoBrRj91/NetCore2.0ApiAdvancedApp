namespace JohnStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         ICommandResult Handler(T Command);
    }
}