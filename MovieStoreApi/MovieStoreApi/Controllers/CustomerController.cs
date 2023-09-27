﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Customers.Commands;
using MovieStoreApi.Customers.Queries;
using MovieStoreCore.Domain;

namespace MovieStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            List<Customer> customers = await _mediator.Send(new GetAllCustomers.Query { });
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomer.Query { Id = id });
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(string customerEmail)
        {
            var createdCustomer = await _mediator.Send(new CreateCustomer.Command { Email = customerEmail });
            return createdCustomer == null ? NoContent() : Ok(createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, string email)
        {
            var updatedCustomer = await _mediator.Send(new UpdateCustomer.Command { Id = id, Email = email });
            return Ok(updatedCustomer);
        }

        [HttpPut("promote/{id}")]
        public async Task<IActionResult> PromoteCustomer(Guid id)
        {
            var updatedCustomer = await _mediator.Send(new PromoteCustomer.Query { Id = id });
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            bool isFound = await _mediator.Send(new DeleteCustomer.Command { Id = id });
            return isFound == false ? NotFound() : Ok(true);
        }

        [HttpPost("{customerId}/purchase/{movieId}")]
        public async Task<IActionResult> PurchaseMovie(Guid customerId, Guid movieId)
        {
            PurchasedMovie purchasedMovie = new PurchasedMovie
            {
                Id = Guid.NewGuid(),
                PurchaseDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(1),
                // Customer = customer,
                // Movie = movie
            };
            // var pur
            // var purchaser = await _mediator.Send(new PurchaseMovie.Query { Customer = customer, Movie = movie });
            //return purchaser == null ? NotFound() : Ok(true);
            return Ok();
        }
    }
}

