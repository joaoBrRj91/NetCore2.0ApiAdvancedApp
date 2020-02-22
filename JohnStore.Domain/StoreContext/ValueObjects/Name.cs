using FluentValidator;
using FluentValidator.Validation;

namespace JohnStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        private Name() { }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(
                new ValidationContract()
                .HasMaxLen(firstName, 30, "FirstName", "Tamanho máximo de 30 caracteres")
                .HasMinLen(firstName, 5, "FirstName", "Tamanho minimo de 5 caracteres")
                .HasMaxLen(lastName, 30, "LastName", "Tamanho máximo de 30 caracteres")
                .HasMinLen(LastName, 5, "LastName", "Tamanho minimo de 5 caracteres"));

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString() => $"{FirstName} - {LastName}";

    }
}