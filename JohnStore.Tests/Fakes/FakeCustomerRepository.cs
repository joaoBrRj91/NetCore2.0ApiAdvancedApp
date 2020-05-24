using johnstore.Domain.StoreContext.Queries;
using JohnStore.Domain.StoreContext.Entities;
using JohnStore.Domain.StoreContext.Repositories;
using System;
using System.Collections.Generic;

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

        public IEnumerable<GetCustomerQueryResult> Get()
        {
            return new List<GetCustomerQueryResult>();
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            return new GetCustomerQueryResult();
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