using System;
using JohnStore.Domain.StoreContext.ValueObjects;
using JohnStore.Shared.Commands;

namespace JohnStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
  public class CreateCustomerCommandResult : ICommandResult
  {

    public CreateCustomerCommandResult()
    {

    }
    public CreateCustomerCommandResult(Guid customer, string name, string email)
    {
      this.Customer = customer;
      this.Name = name;
      this.Email = email;

    }
    public Guid Customer { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

  }
}