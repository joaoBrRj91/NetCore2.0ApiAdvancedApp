using System;
using System.Collections.Generic;
using System.Linq;
using JohnStore.Domain.StoreContext.ValueObjects;
using JohnStore.Shared.Entities;

namespace JohnStore.Domain.StoreContext.Entities
{
  public class Customer : Entity
  {

    protected Customer() { }

    public Customer(
        Name name,
        Document document,
        Email email,
        string phone) : base()
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
    private List<Address> _addresses { get; set; }
    protected ICollection<Address> Addresses { get; set; }


    public void AddAddress(Address address)
    {
      //Validar Endereco
      //Adicionar Endereco
      Addresses.Add(address);
    }

    public List<Address> GetAddresses()
    {
      _addresses = new List<Address>();

      foreach (var address in Addresses)
        _addresses.Add(
            new Address(address.Street,
            address.Number,
            address.Complement,
            address.District,
            address.City,
            address.State,
            address.Country,
            address.ZipCode,
            address.Type));

      return _addresses;
    }

    public override void ValidateEntity()
    {
      AddNotifications(Name.Notifications);
      AddNotifications(Document.Notifications);
      AddNotifications(Email.Notifications);
      AddNotifications(this.Notifications);

    }

    public override string ToString() => Name.ToString();

  }

}