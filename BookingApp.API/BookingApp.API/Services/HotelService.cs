using BookingApp.API.DTOs.Hotels;
using Domain.Entities;
using Infrastructure;

namespace BookingApp.API.Services
{
    public class HotelService : IHotelService
    {
        private readonly AppDbContext _context;

        public HotelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HotelResponseDto> CreateHotelAsync(CreateHotelRequestDto request)
        {
            var hotel = new Hotel(
                title: request.Title,
                description: request.Description,
                rating: request.Rating,
                address: request.Address);

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
