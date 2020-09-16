using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GACWareHousingApi.Models;
using GACWareHousingApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GACWareHousingApi.Controllers
{
    [Authorize]
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataRepository<Customer> _dataRepository;
        public CustomerController(IDataRepository<Customer> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Customer
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Customer> Customers = _dataRepository.GetAll();
            return Ok(Customers);
        }
        // GET: api/Customer/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("Get/{id}")]
        public IActionResult Get(long id)
        {
            Customer Customer = _dataRepository.Get(id);
            if (Customer == null)
            {
                return NotFound("The Customer record couldn't be found.");
            }
            return Ok(Customer);
        }
        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer Customer)
        {
            if (Customer == null)
            {
                return BadRequest("Customer is null.");
            }
            _dataRepository.Add(Customer);
            return CreatedAtRoute(
                  "Get",
                  new { Id = Customer.Id },
                  Customer);
        }
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Customer Customer)
        {
            if (Customer == null)
            {
                return BadRequest("Customer is null.");
            }
            Customer CustomerToUpdate = _dataRepository.Get(id);
            if (CustomerToUpdate == null)
            {
                return NotFound("The Customer record couldn't be found.");
            }
            _dataRepository.Update(CustomerToUpdate, Customer);
            return NoContent();
        }
        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Customer Customer = _dataRepository.Get(id);
            if (Customer == null)
            {
                return NotFound("The Customer record couldn't be found.");
            }
            _dataRepository.Delete(Customer);
            return NoContent();
        }
    }
}