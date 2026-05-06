using BookingApp.API.Data;
using BookingApp.API.DTOs;
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
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelRequestDto request)
        {
            var newHotel = new Hotel
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.Hotels.AddAsync(newHotel);
            await _context.SaveChangesAsync();

            return Ok(newHotel);
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _context.Hotels 
                                .Select(h => new HotelResponseDto
                                {
                                    Id = h.Id,
                                    Title = h.Title,
                                    Description = h.Description,
                                }).ToListAsync();
                                
            return Ok(hotels);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] CreateHotelRequestDto request)
        {
            var exitingHotelUpdate = await _context.Hotels.FindAsync(id);

            if (exitingHotelUpdate == null)
            {
                return NotFound(new { Message = $"Отель с ID {id} не найден" });
            }

            exitingHotelUpdate.Title = request.Title;
            exitingHotelUpdate.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(exitingHotelUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var exitingHotelDel = await _context.Hotels.FindAsync(id);

            if (exitingHotelDel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(exitingHotelDel);
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"Отель {exitingHotelDel.Title} успешно удален" });
        }

    }
}