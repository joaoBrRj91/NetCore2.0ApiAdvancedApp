using FluentValidator;
using JohnStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using JohnStore.Shared.Commands;

namespace JohnStore.Domain.StoreContext.Handlers
{
  public class CustomerHandler : 
  Notifiable,
   ICommandHandler<CreateCustomerCommand>,
   ICommandHandler<AddAddressCustomerCommand>
  {
    public ICommandResult Handler(CreateCustomerCommand Command)
    {
      throw new System.NotImplementedException();
    }

    public ICommandResult Handler(AddAddressCustomerCommand Command)
    {
      throw new System.NotImplementedException();
    }
  }
}