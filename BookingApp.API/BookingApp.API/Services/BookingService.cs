using BookingApp.API.Data;
using BookingApp.API.DTOs;
using BookingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingDbContext _context;

        public BookingService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<Booking?> CreateBookingAsync(CreateBookingRequestDto request)
        {
            // Проверяем, существует ли комната
            var roomExists = await _context.Rooms.AnyAsync(r => r.Id == request.RoomId);
            if (!roomExists) return null;

            // БИЗНЕС-ЛОГИКА: Проверяем пересечение дат (занята ли комната)
            var isRoomTaken = await _context.Bookings.AnyAsync(b =>
                b.RoomId == request.RoomId &&
                request.StartDate < b.CheckOutDate &&
                request.EndDate > b.CheckInDate);

            if (isRoomTaken) return null; // Комната занята

            var newBooking = new Booking
            {
                RoomId = request.RoomId,
                GuestName = request.GuestName,
                CheckInDate = request.StartDate,
                CheckOutDate = request.EndDate
            };

            await _context.Bookings.AddAsync(newBooking);
            await _context.SaveChangesAsync();

            return newBooking;
        }
    }
}