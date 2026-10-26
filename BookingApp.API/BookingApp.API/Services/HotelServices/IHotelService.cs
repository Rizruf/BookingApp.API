using BookingApp.API.DTOs.Hotels;

namespace BookingApp.API.Services.HotelServices
{
    public interface IHotelService
    {
        Task<HotelResponseDto> CreateHotelAsync(CreateHotelRequestDto requestHotel);

        Task<List<HotelResponseDto>> GetHotelsAsync();

        Task<HotelResponseDto?> GetHotelByIdAsync(int id);
    }
}
