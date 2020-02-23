using FluentValidator;
using JohnStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using JohnStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using JohnStore.Domain.StoreContext.Entities;
using JohnStore.Domain.StoreContext.Repositories;
using JohnStore.Domain.StoreContext.Services;
using JohnStore.Domain.StoreContext.ValueObjects;
using JohnStore.Shared.Commands;

namespace JohnStore.Domain.StoreContext.Handlers
{
  public class CustomerHandler :
  Notifiable,
   ICommandHandler<CreateCustomerCommand>,
   ICommandHandler<AddAddressCustomerCommand>
  {

    private readonly ICustomerRepository _customerRepository;
    private readonly ISmsService _smsService;

    public CustomerHandler(ICustomerRepository customerRepository, ISmsService smsService)
    {
      _customerRepository = customerRepository;
      _smsService = smsService;
    }

    public ICommandResult Handler(CreateCustomerCommand command)
    {
      ICommandResult commandResult = null;

      //Verificar o CPF já existe na base
      if (_customerRepository.CheckDocument(command.Document))
      {
        AddNotification("Document", "Este CPF já está em uso");
        return commandResult;
      }

      //Verificar se o E-mail já existe na base
      if (_customerRepository.CheckEmail(command.Email))
      {
        AddNotification("Document", "Este CPF já está em uso");
        return commandResult;
      }

      //Criar VOs => Poderiamos utilizar o Pattern Builder para criar o customer
      var name = new Name(command.FirstNome, command.LastNome);
      var document = new Document(command.Document);
      var email = new Email(command.Email);

      //Criar a entidade
      var customer = new Customer(name, document, email, command.Phone);
      customer.ValidateEntity();
      AddNotifications(customer.Notifications);

      if (Invalid)
        return commandResult;

	//Persistir no banco de dados
	_customerRepository.Save(customer);

	//Enviar e-mail de boas vindas
	_smsService.Send(email.Address,"hello@johnStore.io","Bem vindo","Seja Bem vinto ao John Store!!");

	//Retornar o resultado para a tela
	return new CreateCustomerCommandResult(customer.Id,customer.Name.ToString(),customer.Email.Address);

    }

    public ICommandResult Handler(AddAddressCustomerCommand command)
    {
      throw new System.NotImplementedException();
    }
  }
}