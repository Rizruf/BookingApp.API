using BookingApp.API.DTOs;

namespace BookingApp.API.Services
{
    public interface IHotelService
    {
        Task<List<HotelResponseDto>> GetAllHotelsAsync();
        Task<HotelResponseDto> GetHotelByIdAsync(int id);
        Task<HotelResponseDto> CreateHotelAsync(CreateHotelRequestDto request);
        Task<HotelResponseDto> UpdateHotelAsync(int id, CreateHotelRequestDto request);
        Task<bool> DeleteHotelAsync(int id);
    }
}
