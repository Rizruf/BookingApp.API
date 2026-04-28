using BookingApp.API.Data;
using BookingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<IActionResult> CreateHotel(Hotel newHotel)
        {
            await _context.Hotels.AddAsync(newHotel);

            await _context.SaveChangesAsync();

            return Ok(newHotel);
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();

            return Ok(hotels);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);

            await _context.SaveChangesAsync();

            return Ok(hotel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"Отель {hotel.Title} успешно удален" });
        }

    }
}