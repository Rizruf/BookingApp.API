using BookingApp.API.DTOs.Booking;

namespace BookingApp.API.Services.BookingService
{
    public interface IBookingService
    {
        Task<BookingResponseDto> CreateBookingAsync(CreateBookingRequestDto requestBooking);
        Task<List<BookingResponseDto>> GetBookingsAsync();
        Task<BookingResponseDto?> GetBookingByIdAsync(int id);
        Task<bool> DeleteBookingByIdAsync(int id);
        Task<BookingResponseDto?> UpdateBookingAsync(int id, UpdateBookingRequestDto requestUpdateBooking);
    }
}
