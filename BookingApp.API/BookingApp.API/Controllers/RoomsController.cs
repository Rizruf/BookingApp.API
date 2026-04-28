using BookingApp.API.Data;
using BookingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoomsController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public RoomsController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(Room newRoom)
        {
            await _context.Rooms.AddAsync(newRoom);

            await _context.SaveChangesAsync();

            return Ok(newRoom);
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return Ok(rooms);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(Room newRoom)
        {
            _context.Rooms.Update(newRoom);

            await _context.SaveChangesAsync();

            return Ok(newRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"Комната {room.Title} успешно удалена" });
        }
    }
}
