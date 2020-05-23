using System;
using System.Collections.Generic;
using JohnStore.Domain.StoreContext.ValueObjects;
using JohnStore.Shared.Commands;

namespace JohnStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {

        public CreateCustomerCommandResult(IDictionary<string, string> notifications)
        {
            this.Notifications = notifications;
        }

        public CreateCustomerCommandResult(Guid customer, string name, string email, IDictionary<string, string> notifications)
        {
            this.Customer = customer;
            this.Name = name;
            this.Email = email;
            this.Notifications = notifications;

        }
        public Guid Customer { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Success => Notifications.Count > 0;
        public IDictionary<string, string> Notifications { get; set;  }
    }
}