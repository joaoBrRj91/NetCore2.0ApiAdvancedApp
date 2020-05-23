using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using JohnStore.Domain.StoreContext.Repositories;
using johnstore.Domain.StoreContext.Queries;
using JohnStore.Domain.StoreContext.Handlers;
using JohnStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using JohnStore.Shared.Commands;
using johnstore.shared.Responses;

namespace JohnStore.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository customerRepository;
        private readonly CustomerHandler customerHandler;

        public CustomerController(ICustomerRepository customerRepository, CustomerHandler customerHandler)
        {
            this.customerRepository = customerRepository;
            this.customerHandler = customerHandler;
        }

        [HttpGet("v1")]
        [ResponseCache(Duration =60, Location = ResponseCacheLocation.Client)]
        //Cache-Control: public,max-age=60
        public IEnumerable<GetCustomerQueryResult> Get() => customerRepository.Get();


        [HttpGet("v1/{id}")]
        public GetCustomerQueryResult Get(Guid id) => customerRepository.Get(id);


        [HttpGet("v2/{document}")]
        public GetCustomerQueryResult Get(string document)
        {
            return null;
        }


        [HttpGet("v1/{document}/orders")]
        public CustomerOrdersCountQueryResult GetOrdersByCustomerDocument(string document) => 
            customerRepository.GetCustomerOrdersCount(document);


        [HttpPost]
        public ResponseResult Post([FromBody] CreateCustomerCommand command) => 
            new ResponseResult(customerHandler.Handler(command));

        //// PUT: api/Customer/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Customer customer)
        //{
        //    return new JsonResult(customer)
        //    {
        //        ContentType = "application/json",
        //        StatusCode = (int?)HttpStatusCode.OK
        //    };
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    return new ContentResult()
        //    {
        //        ContentType = "application/json",
        //        StatusCode = (int?)HttpStatusCode.NoContent
        //    };
        //}
    }
}
