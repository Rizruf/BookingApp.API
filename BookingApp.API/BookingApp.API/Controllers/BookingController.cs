using BookingApp.API.DTOs.Booking;
using BookingApp.API.Services.BookingService;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<ActionResult<BookingResponseDto>> CreateBooking([FromBody] CreateBookingRequestDto bookingRequest)
        {
            var responce = await _bookingService.CreateBookingAsync(bookingRequest);
            return Ok(responce);
        }
    }
}
