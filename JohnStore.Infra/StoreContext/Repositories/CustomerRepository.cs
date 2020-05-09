using JohnStore.Domain.StoreContext.Entities;
using JohnStore.Domain.StoreContext.Repositories;
using JohnStore.Infra.StoreContext.DataContext;
using System.Linq;
using Dapper;
using johnstore.Domain.StoreContext.Queries;

namespace JohnStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private JohnStoreDataContext _context;

        public CustomerRepository(JohnStoreDataContext context) => _context = context;


        public bool CheckDocument(string document)
        {
            return
                _context
                .Connection
                .Query<bool>(
                        "sp_CheckDocument",
                        new { Document = document },
                        commandType: System.Data.CommandType.StoredProcedure
                    )
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return
                _context
                .Connection
                .Query<bool>(
                        "sp_CheckEmail",
                        new { Email = email },
                        commandType: System.Data.CommandType.StoredProcedure
                    )
                .FirstOrDefault();
        }

        public CustomerOrdersCountQueryResult GetCustomerOrdersCount(string document)
        {
            return
               _context
               .Connection
               .Query<CustomerOrdersCountQueryResult>(
                       "sp_GetCustomerOrdersCount",
                       new { Document = document },
                       commandType: System.Data.CommandType.StoredProcedure
                   )
               .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            //TODO: É necessário implementar um abertura(BeginTransaction) e o commit da mesma(Utilizar UoW)
            _context.Connection.Execute("sp_CreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Email = customer.Email,
                    Phone = customer.Phone
                }, commandType: System.Data.CommandType.StoredProcedure);


            foreach (var address in customer.GetAddresses())
            {
                _context.Connection.Execute("sp_CreateAddress",
               new
               {
                   Id = customer.Id,
                   CustomerId = customer.Id,
                   Number = address.Number,
                   Complement = address.Complement,
                   District = address.District,
                   City = address.City,
                   State = address.State,
                   Country = address.Country,
                   ZipCode = address.ZipCode,
                   Type = address.Type

               }, commandType: System.Data.CommandType.StoredProcedure);

            }

        }
    }
}
