using BookingApp.API.Data;
using BookingApp.API.DTOs;
using BookingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Services
{
    public class HotelService : IHotelService
    {
        private readonly BookingDbContext _context;

        public HotelService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<HotelResponseDto>> GetAllHotelsAsync()
        {
            var hotels = await _context.Hotels
                .Select(h => new HotelResponseDto
                {
                    Id = h.Id,
                    Title = h.Title,
                    Description = h.Description,
                    Rooms = h.Rooms.Select(r => new RoomsResponseDto
                    {
                        Id = r.Id,
                        Title = r.Title,
                        PricePerNight = r.PricePerNight
                    }).ToList()
                })
                .ToListAsync();

            return hotels;
        }

        public async Task<HotelResponseDto?> GetHotelByIdAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return null;
            }

            return new HotelResponseDto
            {
                Id = hotel.Id,
                Title = hotel.Title,
                Description = hotel.Description
            };
        }

        public async Task<HotelResponseDto> CreateHotelAsync(CreateHotelRequestDto request)
        {
            var newHotel = new Hotel
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _context.Hotels.AddAsync(newHotel);
            await _context.SaveChangesAsync();

            return new HotelResponseDto
            {
                Id = newHotel.Id,
                Title = newHotel.Title,
                Description = newHotel.Description
            };
        }

        public async Task<HotelResponseDto?> UpdateHotelAsync(int id, CreateHotelRequestDto request)
        {
            var existingHotel = await _context.Hotels.FindAsync(id);

            if (existingHotel == null)
            {
                return null;
            }

            existingHotel.Title = request.Title;
            existingHotel.Description = request.Description;

            await _context.SaveChangesAsync();

            return new HotelResponseDto
            {
                Id = existingHotel.Id,
                Title = existingHotel.Title,
                Description = existingHotel.Description
            };
        }

        public async Task<bool> DeleteHotelAsync(int id)
        {
            var existingHotel = await _context.Hotels.FindAsync(id);

            if (existingHotel == null)
            {
                return false;
            }

            _context.Hotels.Remove(existingHotel);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}