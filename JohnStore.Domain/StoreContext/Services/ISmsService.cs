namespace JohnStore.Domain.StoreContext.Services
{
    public interface ISmsService
    {
         void Send(string to,string from,string subject,string body);
    }
}