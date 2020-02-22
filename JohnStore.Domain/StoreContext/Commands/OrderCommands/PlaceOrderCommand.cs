using System;
using System.Collections.Generic;

namespace JohnStore.Domain.StoreContext.Commands.OrderCommands
{
    public class PlaceOrderCommand
    {
        public Guid Customer { get; set; }
        public List<OrdemItemCommand> OrdernItems { get; set; }
    }

    public class OrdemItemCommand
    {
        public Guid Product{get; set;}
        public decimal Quantity { get; set; }
    }
}