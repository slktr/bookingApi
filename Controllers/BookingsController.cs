using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApi.Models;
using BookingApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly MongoDBBookingService _mongoDBService;

        public BookingsController(MongoDBBookingService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        //private readonly ILogger<AdditionalServicesController> _logger;

        //public AdditionalServicesController(ILogger<AdditionalServicesController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet("ReadBookings")]
        public async Task<List<Bookings>> Get()
        {
            return await _mongoDBService.GetAsync();
        }

        [HttpGet("ReadBookingsAvailability")]
        public async Task<bool> GetAvailability(string refName, string bookingDate, int anzahl)
        {
            List<Bookings> bookings = await _mongoDBService.GetFilteredAsync(refName, bookingDate);
            return bookings.Count() < anzahl;
        }

        [HttpPost("CreateBooking")]
        public async Task<IActionResult> Post([FromBody] Bookings bookings)
        {
            await _mongoDBService.CreateAsync(bookings);
            return CreatedAtAction(nameof(Get), new { id = bookings.Id }, bookings);
        }
   
    }
}
