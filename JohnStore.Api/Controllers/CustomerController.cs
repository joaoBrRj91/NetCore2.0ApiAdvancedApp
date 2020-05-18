using System.Collections.Generic;
using System.Net;
using JohnStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace JohnStore.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IEnumerable<Customer> _customers;

        public CustomerController() => _customers = new List<Customer>();

        // GET: api/Customer
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_customers)
            {
                ContentType = "application/json",
                StatusCode = (int?)HttpStatusCode.OK
            };
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            return new JsonResult(customer)
            {
                ContentType = "application/json",
                StatusCode = (int?)HttpStatusCode.OK
            };
        }

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
