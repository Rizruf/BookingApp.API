using BookingApp.API.DTOs.Booking;

namespace BookingApp.API.Services.BookingService
{
    public interface IBookingService
    {
        Task<BookingResponseDto> CreateBookingAsync(CreateBookingRequestDto requestBooking);
    }
}
