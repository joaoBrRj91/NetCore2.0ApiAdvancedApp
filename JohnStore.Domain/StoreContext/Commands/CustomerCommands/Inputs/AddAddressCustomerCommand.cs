using System;
using JohnStore.Domain.StoreContext.Enums;

namespace JohnStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class AddAddressCustomerCommand
    {
        public Guid Customer { get; set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }
        public string Complement { get; protected set; }
        public string District { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string Country { get; protected set; }
        public string ZipCode { get; protected set; }
        public EAddressType Type { get; private set; }

    }
}