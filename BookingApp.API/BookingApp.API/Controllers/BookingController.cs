using BookingApp.API.DTOs;
using BookingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequestDto request)
        {
            var booking = await _bookingService.CreateBookingAsync(request);

            if (booking == null)
            {
                return BadRequest(new { Message = "Комната не найдена или уже занята на эти даты." });
            }

            return Ok(booking);
        }
    }
}