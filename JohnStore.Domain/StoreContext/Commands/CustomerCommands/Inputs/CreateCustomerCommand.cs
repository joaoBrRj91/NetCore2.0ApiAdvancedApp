namespace JohnStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand
    {

        public string FirstNome { get; set; }   
        public string LastNome { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}