using System.Collections.Generic;
using System.Net;
using JohnStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using JohnStore.Domain.StoreContext.Repositories;
using johnstore.Domain.StoreContext.Queries;

namespace JohnStore.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<GetCustomerQueryResult> Get() => customerRepository.Get();

        [HttpGet("{id}")]
        public GetCustomerQueryResult Get(Guid id) => customerRepository.Get(id);

        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            return new JsonResult(customer)
            {
                ContentType = "application/json",
                StatusCode = (int?)HttpStatusCode.Created
            };
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            return new JsonResult(customer)
            {
                ContentType = "application/json",
                StatusCode = (int?)HttpStatusCode.OK
            };
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new ContentResult()
            {
                ContentType = "application/json",
                StatusCode = (int?)HttpStatusCode.NoContent
            };
        }
    }
}
