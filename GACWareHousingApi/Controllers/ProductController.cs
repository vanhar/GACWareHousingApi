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
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataRepository<Product> _dataRepository;
        public ProductController(IDataRepository<Product> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> Products = _dataRepository.GetAll();
            return Ok(Products);
        }
        // GET: api/Product/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("Get/{id}")]
        public IActionResult Get(long id)
        {
            Product Product = _dataRepository.Get(id);
            if (Product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            return Ok(Product);
        }
        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product Product)
        {
            if (Product == null)
            {
                return BadRequest("Product is null.");
            }
            _dataRepository.Add(Product);
            return CreatedAtRoute(
                  "Get",
                  new { Id = Product.Id },
                  Product);
        }
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Product Product)
        {
            if (Product == null)
            {
                return BadRequest("Product is null.");
            }
            Product ProductToUpdate = _dataRepository.Get(id);
            if (ProductToUpdate == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            _dataRepository.Update(ProductToUpdate, Product);
            return NoContent();
        }
        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Product Product = _dataRepository.Get(id);
            if (Product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            _dataRepository.Delete(Product);
            return NoContent();
        }
    }
}