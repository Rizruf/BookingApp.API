using BookingApp.API.Data;
using BookingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> CreateBooking(Booking newBooking)
        {
            bool isRoomTaken = await _context.Bookings.AnyAsync(b =>
                b.RoomId == newBooking.RoomId && 
                newBooking.CheckInDate < b.CheckOutDate && 
                newBooking.CheckOutDate > b.CheckInDate    
            );

            if (isRoomTaken)
            {
                return BadRequest(new { Message = "Извините, номер уже занят на эти даты." });
            }

            await _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();

            return Ok(newBooking);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _context.Bookings
                                .Include(b => b.Room)
                                .ToListAsync();
            return Ok(bookings);
        }


    }
}
