using BookingApp.API.Data;
using BookingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase 
    {
        private readonly BookingDbContext _context;

        public HotelsController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetHotels()
        {
            var hotels = _context.Hotels.ToList();

            return Ok(hotels);
        }

        [HttpPost]
        public IActionResult CreateHotel(Hotel newHotel)
        {
            _context.Hotels.Add(newHotel);

            _context.SaveChanges();

            return Ok(newHotel);
        }
    }
}