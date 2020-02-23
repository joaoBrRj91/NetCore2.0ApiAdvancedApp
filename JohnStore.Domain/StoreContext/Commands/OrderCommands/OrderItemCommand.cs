namespace JohnStore.Domain.StoreContext.Commands.OrderCommands
{
  public class OrderItemCommand
  {
    public System.Guid Product { get; set; }
    public decimal Quantity { get; set; }
  }
}