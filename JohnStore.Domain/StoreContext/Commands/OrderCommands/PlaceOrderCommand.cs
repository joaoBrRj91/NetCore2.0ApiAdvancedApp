using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using JohnStore.Shared.Commands;

namespace JohnStore.Domain.StoreContext.Commands.OrderCommands
{
  public class PlaceOrderCommand : Notifiable, ICommand
  {
    public Guid Customer { get; set; }
    public List<OrderItemCommand> OrderItems { get; set; }

    //FAIL FAST VALIDATION
    public bool IsValidCommand()
    {

      AddNotifications(
               new ValidationContract()
               .HasMaxLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
               .IsGreaterThan(OrderItems.Count, 0, "OrderItems", "Nenhum item do pedido foi encontrado"));

      return base.IsValid;

    }

  }
}