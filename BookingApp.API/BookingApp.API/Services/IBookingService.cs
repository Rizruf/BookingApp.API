using BookingApp.API.DTOs;
using BookingApp.API.Models;

namespace BookingApp.API.Services
{
    public interface IBookingService
    {
        Task<Booking?> CreateBookingAsync(CreateBookingRequestDto request);
    }
}