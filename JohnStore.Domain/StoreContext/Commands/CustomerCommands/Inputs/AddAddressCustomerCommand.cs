using System;
using FluentValidator;
using FluentValidator.Validation;
using JohnStore.Domain.StoreContext.Enums;
using JohnStore.Shared.Commands;

namespace JohnStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
  public class AddAddressCustomerCommand : Notifiable, ICommand
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
    public EAddressType Type { get; protected set; }

    public bool IsValidCommand()
    {
       AddNotifications(
          new ValidationContract()
          .HasMaxLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
          .IsNotNullOrEmpty(Street, "Street", "Cidade deve ser informada")
          .IsNotNullOrEmpty(Number, "Number", "Numero deve ser informado")
          .IsNotNullOrEmpty(Complement,"Complement", "Complemento deve ser informado")
          .IsNotNullOrEmpty(District, "District", "Distrito deve ser informado")
          .IsNotNullOrEmpty(City, "City", "Cidade deve ser informada")
          .IsNotNullOrEmpty(State, "State", "Estado deve ser informado")
          .IsNotNullOrEmpty(Country, "Country", "Pais deve ser informado")
          .IsNotNullOrEmpty(ZipCode, "ZipCode", "Codigo postal deve ser informad0"));

      return base.IsValid;
      
    }
  }
}