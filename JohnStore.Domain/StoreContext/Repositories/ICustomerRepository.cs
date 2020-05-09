using johnstore.Domain.StoreContext.Queries;
using JohnStore.Domain.StoreContext.Entities;

namespace JohnStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountQueryResult GetCustomerOrdersCount(string document);

    }
}