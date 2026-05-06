using BookingApp.API.Data;
using BookingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApp.API.DTOs;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookingController : ControllerBase
    {
        private readonly BookingDbContext _context;

        public BookingController(BookingDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequestDto request)
        {
            bool isRoomTaken = await _context.Bookings.AnyAsync(b =>
                b.RoomId == request.RoomId &&
                request.StartDate < b.CheckOutDate &&
                request.EndDate > b.CheckInDate
            );

            if (isRoomTaken)
            {
                return BadRequest(new { Message = "Извините, номер уже занят на эти даты." });
            }

            var newBooking = new Booking
            {
                RoomId = request.RoomId,
                CheckInDate = request.StartDate,
                CheckOutDate = request.EndDate,
                GuestName = "Гость"
            };

            await _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();

            return Ok(newBooking);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _context.Bookings
                                .Select(b => new BookingResponseDto
                                {
                                    Id = b.Id,
                                    CheckInDate = b.CheckInDate,
                                    CheckOutDate= b.CheckOutDate,
                                    GuestName = b.GuestName,

                                }).ToListAsync();
            return Ok(bookings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] CreateBookingRequestDto request)
        {
            var existingBooking = await _context.Bookings.FindAsync(id);

            if (existingBooking == null)
            {
                return NotFound(new { Message = $"Бронь с ID {id} не найдена" });
            }

            bool isRoomTaken = await _context.Bookings.AnyAsync(b =>
                b.RoomId == request.RoomId &&
                b.Id != id && 
                request.StartDate < b.CheckOutDate &&
                request.EndDate > b.CheckInDate
            );

            if (isRoomTaken)
            {
                return BadRequest(new { Message = "Извините, номер уже занят на эти измененные даты." });
            }

            existingBooking.RoomId = request.RoomId;
            existingBooking.CheckInDate = request.StartDate;
            existingBooking.CheckOutDate = request.EndDate;

            await _context.SaveChangesAsync();

            return Ok(existingBooking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound(new { Message = $"Бронь с ID {id} не найдена" });
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"Бронь успешно удалена" });
        }

    }
}
