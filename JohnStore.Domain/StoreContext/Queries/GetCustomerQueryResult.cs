using System;
using System.Collections.Generic;
using System.Text;

namespace johnstore.Domain.StoreContext.Queries
{
    public class GetCustomerQueryResult
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
