using JohnStore.Domain.StoreContext.Entities;
using JohnStore.Domain.StoreContext.Repositories;

public class FakeCustomerRepository : ICustomerRepository
{
    public bool CheckDocument(string document)
    {
        return true;
    }

    public bool CheckEmail(string email)
    {
        return true;
    }

    public void Save(Customer customer)
    {
       
    }
}