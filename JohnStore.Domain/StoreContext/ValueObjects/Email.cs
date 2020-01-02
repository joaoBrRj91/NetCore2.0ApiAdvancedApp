using FluentValidator;
using FluentValidator.Validation;

namespace JohnStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        private Email() { }
        public Email(string address)
        {
            Address = address;
            AddNotifications(new ValidationContract().IsEmail(Address, "Address", "Email no formato inválido"));

        }

        public string Address { get; private set; }

    }
}