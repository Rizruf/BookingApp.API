using BookingApp.API.DTOs.Booking;
using BookingApp.API.DTOs.Guests;
using BookingApp.API.DTOs.Rooms;

namespace BookingApp.API.Services.GuestService
{
    public interface IGuestService
    {
        Task<GuestResponseDto> CreateGuestAsync(CreateGuestRequestDto requestGuest);
        Task<List<GuestResponseDto>> GetGuestsAsync();
        Task<GuestResponseDto?> GetGuestByIdAsync(int id);
        Task<bool> DeleteGuestByIdAsync(int id);
        Task<GuestResponseDto?> UpdateGuestAsync(int id, UpdateGuestRequestDto requestUpdateGuest);
    }
}
