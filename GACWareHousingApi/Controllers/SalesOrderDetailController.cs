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
    [Route("api/SalesOrderDetail")]
    [ApiController]
    public class SalesOrderDetailController : ControllerBase
    {
        private readonly IDataRepository<SalesOrderDetail> _dataRepository;
        public SalesOrderDetailController(IDataRepository<SalesOrderDetail> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/SalesOrderDetail
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<SalesOrderDetail> SalesOrderDetails = _dataRepository.GetAll();
            return Ok(SalesOrderDetails);
        }
        // GET: api/SalesOrderDetail/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("Get/{id}")]
        public IActionResult Get(long id)
        {
            SalesOrderDetail SalesOrderDetail = _dataRepository.Get(id);
            if (SalesOrderDetail == null)
            {
                return NotFound("The SalesOrderDetail record couldn't be found.");
            }
            return Ok(SalesOrderDetail);
        }
        // POST: api/SalesOrderDetail
        [HttpPost]
        public IActionResult Post([FromBody] SalesOrderDetail SalesOrderDetail)
        {
            if (SalesOrderDetail == null)
            {
                return BadRequest("SalesOrderDetail is null.");
            }
            _dataRepository.Add(SalesOrderDetail);
            return CreatedAtRoute(
                  "Get",
                  new { Id = SalesOrderDetail.Id },
                  SalesOrderDetail);
        }
        // PUT: api/SalesOrderDetail/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] SalesOrderDetail SalesOrderDetail)
        {
            if (SalesOrderDetail == null)
            {
                return BadRequest("SalesOrderDetail is null.");
            }
            SalesOrderDetail SalesOrderDetailToUpdate = _dataRepository.Get(id);
            if (SalesOrderDetailToUpdate == null)
            {
                return NotFound("The SalesOrderDetail record couldn't be found.");
            }
            _dataRepository.Update(SalesOrderDetailToUpdate, SalesOrderDetail);
            return NoContent();
        }
        // DELETE: api/SalesOrderDetail/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            SalesOrderDetail SalesOrderDetail = _dataRepository.Get(id);
            if (SalesOrderDetail == null)
            {
                return NotFound("The SalesOrderDetail record couldn't be found.");
            }
            _dataRepository.Delete(SalesOrderDetail);
            return NoContent();
        }
    }
}