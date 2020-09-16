using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using GACWareHousingApi.Helpers;
using GACWareHousingApi.Models;
using GACWareHousingApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GACWareHousingApi.Controllers
{
    [Authorize]
    [Route("api/SalesOrder")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly IDataRepository<SalesOrder> _dataRepository;
        private readonly IDataRepository<SalesOrderDetail> _orderDetailRepository;
        public SalesOrderController(IDataRepository<SalesOrder> dataRepository, IDataRepository<SalesOrderDetail> orderDetailRepository)
        {
            _dataRepository = dataRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        // GET: api/SalesOrder
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<SalesOrder> SalesOrders = _dataRepository.GetAll();
            return Ok(SalesOrders);
        }
        // GET: api/SalesOrder/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("Get/{id}")]
        public IActionResult Get(long id)
        {
            SalesOrder SalesOrder = _dataRepository.Get(id);
            if (SalesOrder == null)
            {
                return NotFound("The SalesOrder record couldn't be found.");
            }
            return Ok(SalesOrder);
        }
        // POST: api/SalesOrder
        [HttpPost]
        public IActionResult Post([FromBody] string xml)
        {
            IEnumerable<SalesOrder> SalesOrders = XmlParserHandler.ParseSalesOrder(xml);

            if (SalesOrders == null)
            {
                return BadRequest("SalesOrder is null.");
            }
            foreach (var SalesOrder in SalesOrders)
            {
                IEnumerable<SalesOrderDetail> SalesOrderDetails = SalesOrder.SalesOrderDetails;
                SalesOrder.SalesOrderDetails = null;
                _dataRepository.Add(SalesOrder);
                foreach (var SalesOrderDetail in SalesOrderDetails)
                {
                    _orderDetailRepository.Add(SalesOrderDetail);
                }
            }
            return Ok("Success");
        }
        // PUT: api/SalesOrder/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] SalesOrder SalesOrder)
        {
            if (SalesOrder == null)
            {
                return BadRequest("SalesOrder is null.");
            }
            SalesOrder SalesOrderToUpdate = _dataRepository.Get(id);
            if (SalesOrderToUpdate == null)
            {
                return NotFound("The SalesOrder record couldn't be found.");
            }
            _dataRepository.Update(SalesOrderToUpdate, SalesOrder);
            return NoContent();
        }
        // DELETE: api/SalesOrder/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            SalesOrder SalesOrder = _dataRepository.Get(id);
            if (SalesOrder == null)
            {
                return NotFound("The SalesOrder record couldn't be found.");
            }
            _dataRepository.Delete(SalesOrder);
            return NoContent();
        }
    }
}