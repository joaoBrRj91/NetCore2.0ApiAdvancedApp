using FluentValidator;
using FluentValidator.Validation;
using JohnStore.Shared.Commands;

namespace JohnStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
  public class CreateCustomerCommand : Notifiable, ICommand
  {

    public string FirstNome { get; set; }
    public string LastNome { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    //FAIL FAST VALIDATION
    public bool IsValidCommand()
    {
      AddNotifications(
          new ValidationContract()
          .HasMaxLen(FirstNome, 30, "FirstName", "Tamanho máximo de 30 caracteres")
          .HasMinLen(FirstNome, 5, "FirstName", "Tamanho minimo de 5 caracteres")
          .HasMaxLen(LastNome, 30, "LastName", "Tamanho máximo de 30 caracteres")
          .HasMinLen(LastNome, 5, "LastName", "Tamanho minimo de 5 caracteres")
          .IsEmail(Email, "Address", "Email no formato inválido")
          .HasLen(Document, 11, "Document", "CPF Inválido"));

      return base.IsValid;

    }
  }
}