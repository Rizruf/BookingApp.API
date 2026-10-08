using BookingApp.API.DTOs.Guests;
using BookingApp.API.DTOs.Rooms;

namespace BookingApp.API.Services.GuestService
{
    public interface IGuestService
    {
        Task<GuestResponseDto> CreateGuestAsync (CreateGuestRequestDto requestGuest); 
    }
}
