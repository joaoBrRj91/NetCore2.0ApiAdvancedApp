

using System;

namespace johnstore.Domain.StoreContext.Queries
{
    public class CustomerOrdersCountQueryResult
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Document { get; set; }
        public int Orders { get; set; }

    }
}
