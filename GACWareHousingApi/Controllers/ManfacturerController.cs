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
    [Route("api/Manfacturer")]
    [ApiController]
    public class ManfacturerController : ControllerBase
    {
        private readonly IDataRepository<Manfacturer> _dataRepository;
        public ManfacturerController(IDataRepository<Manfacturer> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Manfacturer
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Manfacturer> Manfacturers = _dataRepository.GetAll();
            return Ok(Manfacturers);
        }
        // GET: api/Manfacturer/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("Get/{id}")]
        public IActionResult Get(long id)
        {
            Manfacturer Manfacturer = _dataRepository.Get(id);
            if (Manfacturer == null)
            {
                return NotFound("The Manfacturer record couldn't be found.");
            }
            return Ok(Manfacturer);
        }
        // POST: api/Manfacturer
        [HttpPost]
        public IActionResult Post([FromBody] Manfacturer Manfacturer)
        {
            if (Manfacturer == null)
            {
                return BadRequest("Manfacturer is null.");
            }
            _dataRepository.Add(Manfacturer);
            return CreatedAtRoute(
                  "Get",
                  new { Id = Manfacturer.Id },
                  Manfacturer);
        }
        // PUT: api/Manfacturer/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Manfacturer Manfacturer)
        {
            if (Manfacturer == null)
            {
                return BadRequest("Manfacturer is null.");
            }
            Manfacturer ManfacturerToUpdate = _dataRepository.Get(id);
            if (ManfacturerToUpdate == null)
            {
                return NotFound("The Manfacturer record couldn't be found.");
            }
            _dataRepository.Update(ManfacturerToUpdate, Manfacturer);
            return NoContent();
        }
        // DELETE: api/Manfacturer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Manfacturer Manfacturer = _dataRepository.Get(id);
            if (Manfacturer == null)
            {
                return NotFound("The Manfacturer record couldn't be found.");
            }
            _dataRepository.Delete(Manfacturer);
            return NoContent();
        }
    }
}