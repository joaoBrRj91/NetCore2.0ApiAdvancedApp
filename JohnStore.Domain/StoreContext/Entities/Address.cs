using JohnStore.Domain.StoreContext.Enums;
using JohnStore.Shared.Entities;

namespace JohnStore.Domain.StoreContext.Entities
{
    public class Address : Entity
    {
        protected Address() { }
        public Address(
            string street,
            string number,
            string complement,
            string district,
            string city,
            string state,
            string country,
            string zipCode,
            EAddressType type)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Type = type;
        }

        public string Street { get; protected set; }
        public string Number { get; protected set; }
        public string Complement { get; protected set; }
        public string District { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string Country { get; protected set; }
        public string ZipCode { get; protected set; }
        public EAddressType Type { get; protected set; }

    }
}