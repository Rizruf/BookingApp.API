using BookingApp.API.DTOs.Booking;
using BookingApp.API.DTOs.Guests;
using BookingApp.API.DTOs.Hotels;

namespace BookingApp.API.Services.HotelServices
{
    public interface IHotelService
    {
        Task<HotelResponseDto> CreateHotelAsync(CreateHotelRequestDto requestHotel);
        Task<List<HotelResponseDto>> GetHotelsAsync();
        Task<HotelResponseDto?> GetHotelByIdAsync(int id);
        Task<bool> DeleteHotelByIdAsync(int id);
        Task<HotelResponseDto?> UpdateHotelAsync(int id, UpdateHotelRequestDto requestUpdateHotel);
    }
}
