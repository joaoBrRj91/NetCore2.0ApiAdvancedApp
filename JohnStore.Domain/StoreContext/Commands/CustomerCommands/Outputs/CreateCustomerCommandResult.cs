using System;
using JohnStore.Domain.StoreContext.ValueObjects;
using JohnStore.Shared.Commands;

namespace JohnStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
  public class CreateCustomerCommandResult : ICommandResult
  {
    public Guid Customer { get; set; }
    public Name Name { get; set; }
    public Email Email { get; set; }

  }
}