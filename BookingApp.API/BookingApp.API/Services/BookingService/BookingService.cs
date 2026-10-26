using BookingApp.API.DTOs.Booking;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BookingResponseDto> CreateBookingAsync(CreateBookingRequestDto requestBooking)
        {

            var booking = new Booking (
                checkIn: requestBooking.CheckIn,
                checkOut: requestBooking.CheckOut,
                guestId: requestBooking.GuestId,
                roomId: requestBooking.RoomId);

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return new BookingResponseDto
            {
                Id = booking.Id,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestId = booking.GuestId,
                RoomId = booking.RoomId
            };
        }

        public async Task<List<BookingResponseDto>> GetBookingsAsync()
        {
            var bookings = await _context.Bookings
                            .Select(booking => new BookingResponseDto
                            {
                                Id = booking.Id,
                                CheckIn = booking.CheckIn,
                                CheckOut = booking.CheckOut,
                                GuestId = booking.GuestId,
                                RoomId = booking.RoomId

                            }).ToListAsync();

            return bookings;
        }

        public async Task<BookingResponseDto?> GetBookingByIdAsync(int id)
        {
            var booking = await _context.Bookings
                            .Select(booking => new BookingResponseDto
                            {
                                Id = booking.Id,
                                CheckIn = booking.CheckIn,
                                CheckOut = booking.CheckOut,
                                GuestId = booking.GuestId,
                                RoomId = booking.RoomId

                            }).FirstOrDefaultAsync(x => x.Id == id);

            return booking;
        }
    }
}
