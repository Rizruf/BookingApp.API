using BookingApp.API.DTOs.Booking;
using BookingApp.API.DTOs.Guests;
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

        [HttpPost]
        public async Task<ActionResult<BookingResponseDto>> CreateBooking([FromBody] CreateBookingRequestDto bookingRequest)
        {
            var response = await _bookingService.CreateBookingAsync(bookingRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingResponseDto>>> GetBooking()
        {
            var response = await _bookingService.GetBookingsAsync();
            return response;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<BookingResponseDto?>> GetBookingByIdAsync(int id)
        {
            var response = await _bookingService.GetBookingByIdAsync(id);
            if (response == null) return NotFound();
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookingByIdAsync(int id)
        {
            var response = await _bookingService.DeleteBookingByIdAsync(id);
            if (response) return NoContent();
            return NotFound();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookingResponseDto>> UpdateBookingtasync(int id, [FromBody] UpdateBookingRequestDto bookingRequest)
        {
            var response = await _bookingService.UpdateBookingAsync(id, bookingRequest);
            if (response == null) return NotFound();
            return Ok(response);

        }
    }
}
