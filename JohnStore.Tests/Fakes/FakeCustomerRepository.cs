using johnstore.Domain.StoreContext.Queries;
using JohnStore.Domain.StoreContext.Entities;
using JohnStore.Domain.StoreContext.Repositories;


namespace JohnStore.Tests.Fakes
{

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

        public CustomerOrdersCountQueryResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer)
        {

        }
    }
}