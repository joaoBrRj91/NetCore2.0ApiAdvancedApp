
using JohnStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using JohnStore.Domain.StoreContext.Handlers;
using JohnStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace JohnStore.Tests.ValueObjects
{

    [TestClass]
    class CustomerHandlerTests
    {

        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {

            var command = new CreateCustomerCommand();
            command.FirstNome = "João";
            command.LastNome = "Nascimento";
            command.Document = "12345678914";
            command.Email = "joao91.nascimento@gmail.com";
            command.Phone = "2148987841";

            Assert.Equals(true, command.IsValidCommand());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handler(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);

        }
    }
}