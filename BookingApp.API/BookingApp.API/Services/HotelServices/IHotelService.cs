using BookingApp.API.DTOs.Hotels;

namespace BookingApp.API.Services.HotelServices
{
    public interface IHotelService
    {
        Task<HotelResponseDto> CreateHotelAsync(CreateHotelRequestDto requestHotel);
    }
}
