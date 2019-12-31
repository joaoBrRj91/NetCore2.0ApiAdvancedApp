using System;
using System.Collections.Generic;
using System.Linq;
using JohnStore.Domain.StoreContext.ValueObjects;

namespace JohnStore.Domain.StoreContext.Entities
{
    public class Customer
    {

        protected Customer() { }

        public Customer(
            Name name,
            Document document,
            Email email,
            string phone)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this.Addresses = new List<Address>();
        }

        public Name Name { get; protected set; }
        public Document Document { get; protected set; }
        public Email Email { get; protected set; }
        public string Phone { get; protected set; }
        protected ICollection<Address> Addresses { get; set; }


        public void AddAddress(Address address)
        {
            //Validar Endereco
            //Adicionar Endereco
            Addresses.Add(address);
        }

        public List<Address> GetAddresses()
        {
            var addresses = new List<Address>();
            addresses.AddRange(Addresses.ToArray());
            return addresses;
        }

        public override string ToString() => Name.ToString();

    }

}