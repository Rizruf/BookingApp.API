using BookingApp.API.DTOs.Guests;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Services.GuestService
{
    public class GuestService : IGuestService
    {
        private readonly AppDbContext _context;

        public GuestService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GuestResponseDto> CreateGuestAsync(CreateGuestRequestDto requestGuest)
        {
            var guest = new Guest(
                name: requestGuest.Name,
                surname: requestGuest.Surname,
                phoneNumber: requestGuest.PhoneNumber,
                gender: requestGuest.Gender);

            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();

            return new GuestResponseDto
            {
                Id = guest.Id,
                Name = guest.Name,
                Surname = guest.Surname,
                PhoneNumber = guest.PhoneNumber,
                Gender = guest.Gender
            };
        }

        public async Task<List<GuestResponseDto>> GetGuestsAsync()
        {
            var guests = await _context.Guests
                               .Select(guest => new GuestResponseDto
                               {
                                   Id = guest.Id,
                                   Name = guest.Name,
                                   Surname = guest.Surname,
                                   PhoneNumber = guest.PhoneNumber,
                                   Gender = guest.Gender

                               }).ToListAsync();

            return guests;
        }

        public async Task<GuestResponseDto?> GetGuestByIdAsync(int id)
        {
            var guest = await _context.Guests
                               .Select(guest => new GuestResponseDto
                               {
                                   Id = guest.Id,
                                   Name = guest.Name,
                                   Surname = guest.Surname,
                                   PhoneNumber = guest.PhoneNumber,
                                   Gender = guest.Gender

                               }).FirstOrDefaultAsync(x => x.Id == id);

            return guest;
        }
    }
}
