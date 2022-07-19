using System.Collections.Generic;
using System.Threading.Tasks;
using BookingApi.Models;
using BookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalServicesController : ControllerBase
    {
        private readonly MongoDBAdditionalService _mongoDBService;

        public AdditionalServicesController(MongoDBAdditionalService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        //private readonly ILogger<AdditionalServicesController> _logger;

        //public AdditionalServicesController(ILogger<AdditionalServicesController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet("ReadAdditionalServices")]
        public async Task<List<AdditionalServices>> Get()
        {
            return await _mongoDBService.GetAsync();
        }

        [HttpPost("CreateAdditionalService")]
        public async Task<IActionResult> Post([FromBody] AdditionalServices additionalServices)
        {
            await _mongoDBService.CreateAsync(additionalServices);
            return CreatedAtAction(nameof(Get), new { id = additionalServices.Id }, additionalServices);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }

    }
}
