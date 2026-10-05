using BookingApp.API.DTOs.Hotels;

namespace BookingApp.API.Services
{
    public interface IHotelService
    {
        Task<HotelResponseDto> CreateHotelAsync(CreateHotelRequestDto request);
    }
}
