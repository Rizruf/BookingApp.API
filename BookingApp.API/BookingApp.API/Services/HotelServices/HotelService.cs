using BookingApp.API.DTOs.Hotels;
using Domain.Entities;
using Infrastructure;

namespace BookingApp.API.Services.HotelServices
{
    public class HotelService : IHotelService
    {
        private readonly AppDbContext _context;

        public HotelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HotelResponseDto> CreateHotelAsync(CreateHotelRequestDto requestHotel)
        {
            var hotel = new Hotel(
                title: requestHotel.Title,
                description: requestHotel.Description,
                rating: requestHotel.Rating,
                address: requestHotel.Address);

            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();

            return new HotelResponseDto
            {
                Id = hotel.Id,
                Title = hotel.Title,
                Description = hotel.Description,
                Rating = hotel.Rating,
                Address = hotel.Address
            };
        }
    }
}
