using johnstore.Domain.StoreContext.Queries;
using JohnStore.Domain.StoreContext.Entities;
using System;
using System.Collections.Generic;

namespace JohnStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountQueryResult GetCustomerOrdersCount(string document);
        IEnumerable<GetCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);

    }
}