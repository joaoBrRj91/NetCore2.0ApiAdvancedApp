﻿using System.Collections.Generic;
using System.Net;
using JohnStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using JohnStore.Domain.StoreContext.Repositories;
using johnstore.Domain.StoreContext.Queries;
using JohnStore.Domain.StoreContext.Handlers;
using JohnStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using JohnStore.Shared.Commands;

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

        [HttpGet]
        public IEnumerable<GetCustomerQueryResult> Get() => customerRepository.Get();

        [HttpGet("{id}")]
        public GetCustomerQueryResult Get(Guid id) => customerRepository.Get(id);

        [HttpPost]
        public ICommandResult Post([FromBody] CreateCustomerCommand command)
        {
            return customerHandler.Handler(command);
        }

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
