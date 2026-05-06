using BookingApp.API.Data;
using BookingApp.API.DTOs;
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
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequestDto request)
        {
            var newRoom = new Room
            {
                Title = request.Title,
                PricePerNight = request.PricePerNight,
                HotelId = request.HotelId
            };

            await _context.Rooms.AddAsync(newRoom);
            await _context.SaveChangesAsync();

            return Ok(newRoom);
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _context.Rooms
                                .Select(r => new RoomsResponseDto
                                {
                                    Id = r.Id,
                                    Title = r.Title,
                                    PricePerNight = r.PricePerNight,

                                }).ToListAsync();

            return Ok(rooms);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] CreateRoomRequestDto request)
        {
            var existingRoom = await _context.Rooms.FindAsync(id);

            if (existingRoom == null)
            {
                return NotFound(new { Message = $"Комната с ID {id} не найдена" });
            }

            existingRoom.Title = request.Title;
            existingRoom.PricePerNight = request.PricePerNight;
            existingRoom.HotelId = request.HotelId;

            await _context.SaveChangesAsync();

            return Ok(existingRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var existingRoomDel = await _context.Rooms.FindAsync(id);

            if (existingRoomDel == null)
            {
                return NotFound(new { Message = $"Комната с ID {id} не найдена" });
            }

            _context.Rooms.Remove(existingRoomDel);
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"Комната {existingRoomDel.Title} успешно удалена" });
        }
    }
}
