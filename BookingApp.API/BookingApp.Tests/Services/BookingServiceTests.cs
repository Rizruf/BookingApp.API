using Azure.Core;
using BookingApp.API.DTOs.Booking;
using BookingApp.API.Services.BookingService;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Tests.Services
{
    public class BookingServiceTests
    {
        private AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetBookingByIdAsync_WhenBookingDoesNotExist_ReturnsNull()
        {
            using var context = CreateDbContext();
            var sut = new BookingService(context);

            var result = await sut.GetBookingByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateBookingAsync_WhenRequestIsValid_SavesAndReturnsBooking() 
        {
            using var context = CreateDbContext();
            var sut = new BookingService(context);

            var request = new CreateBookingRequestDto
            {
                CheckIn = new DateOnly(2026, 12, 1),
                CheckOut = new DateOnly(2026, 12, 10),
                GuestId = 1,
                RoomId = 2
            };

            var result = await sut.CreateBookingAsync(request);


            Assert.NotNull(result);
            Assert.True(result.Id > 0);
            Assert.Equal(request.CheckIn, result.CheckIn);
            Assert.Equal(request.CheckOut, result.CheckOut);
            Assert.Equal(request.GuestId, result.GuestId);
            Assert.Equal(request.RoomId, result.RoomId);

            var bookingInDb = await context.Bookings.FirstOrDefaultAsync(b => b.Id == result.Id, cancellationToken: TestContext.Current.CancellationToken);
            Assert.NotNull(bookingInDb);
        }

        [Fact]
        public async Task GetBookingsAsync_WhenBookingsExist_ReturnsAllBookings()
        {
            using var context = CreateDbContext();

            var booking1 = new Booking(
                checkIn: new DateOnly(2026, 12, 1),
                checkOut: new DateOnly(2026, 12, 5),
                guestId: 1,
                roomId: 1);

            var booking2 = new Booking(
                checkIn: new DateOnly(2026, 12, 10),
                checkOut: new DateOnly(2026, 12, 15),
                guestId: 2,
                roomId: 2);

            await context.Bookings.AddRangeAsync(booking1, booking2);
            await context.SaveChangesAsync(TestContext.Current.CancellationToken);

            var sut = new BookingService(context);

            var result = await sut.GetBookingsAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task DeleteBookingByIdAsync_WhenBookingExists_ReturnsTrueAndDeletesBooking()
        {
            using var context = CreateDbContext();

            var booking = new Booking(
                checkIn: new DateOnly(2026, 12, 1),
                checkOut: new DateOnly(2026, 12, 5),
                guestId: 1,
                roomId: 1);

            await context.Bookings.AddAsync(booking, TestContext.Current.CancellationToken);
            await context.SaveChangesAsync(TestContext.Current.CancellationToken);

            var sut = new BookingService(context);

            var result = await sut.DeleteBookingByIdAsync(booking.Id);

            var research = await context.Bookings.FirstOrDefaultAsync(b => b.Id == booking.Id, cancellationToken: TestContext.Current.CancellationToken);

            Assert.True(result);
            Assert.Null(research);
        }

        [Fact]
        public async Task DeleteBookingByIdAsync_WhenBookingDoesNotExist_ReturnsFalse()
        {
            using var context = CreateDbContext();
            var sut = new BookingService(context);

            var result = await sut.DeleteBookingByIdAsync(9999);

            Assert.False(result);
        }

        [Fact]
        public async Task GetBookingByIdAsync_WhenBookingExists_ReturnsBookingDto()
        {
            using var context = CreateDbContext();

            var booking = new Booking(
                checkIn: new DateOnly(2026, 12, 1),
                checkOut: new DateOnly(2026, 12, 5),
                guestId: 1,
                roomId: 1);

            await context.Bookings.AddAsync(booking, TestContext.Current.CancellationToken);
            await context.SaveChangesAsync(TestContext.Current.CancellationToken);

            var sut = new BookingService(context);

            var result = await sut.GetBookingByIdAsync(booking.Id);

            Assert.NotNull(result);
            Assert.True(result.Id > 0);
            Assert.Equal(result.CheckIn, booking.CheckIn);
            Assert.Equal(result.CheckOut, booking.CheckOut);
            Assert.Equal(result.GuestId, booking.GuestId);
            Assert.Equal(result.RoomId, booking.RoomId);
        }

        [Fact]
        public async Task UpdateBookingAsync_WhenBookingExist_ReturnNewDtoBooking()
        {
            using var context = CreateDbContext();

            var booking = new Booking(
                checkIn: new DateOnly(2026, 12, 1),
                checkOut: new DateOnly(2026, 12, 5),
                guestId: 1,
                roomId: 1);

            await context.Bookings.AddAsync(booking, TestContext.Current.CancellationToken);
            await context.SaveChangesAsync(TestContext.Current.CancellationToken);

            var updateRequest = new UpdateBookingRequestDto
            {
                CheckIn = new DateOnly(2026, 12, 10),
                CheckOut = new DateOnly(2026, 12, 20),
                GuestId = 2,
                RoomId = 2
            };

            var sut = new BookingService(context);

            var result = await sut.UpdateBookingAsync(booking.Id, updateRequest);

            Assert.NotNull(result);
            Assert.Equal(booking.Id, result.Id);
            Assert.Equal(updateRequest.CheckIn, result.CheckIn);
            Assert.Equal(updateRequest.CheckOut, result.CheckOut);
            Assert.Equal(updateRequest.GuestId, result.GuestId);
            Assert.Equal(updateRequest.RoomId, result.RoomId);

            var updatedInDb = await context.Bookings.FirstOrDefaultAsync(b => b.Id == booking.Id, cancellationToken: TestContext.Current.CancellationToken);

            Assert.NotNull(updatedInDb);
            Assert.Equal(updateRequest.CheckIn, updatedInDb.CheckIn);
            Assert.Equal(updateRequest.CheckOut, updatedInDb.CheckOut);
        }

        [Fact]
        public async Task UpdateBookingAsync_WhenBookingDoesNotExist_ReturnNull()
        {
            using var context = CreateDbContext();
            var sut = new BookingService(context);

            var updateRequest = new UpdateBookingRequestDto
            {
                CheckIn = new DateOnly(2026, 12, 10),
                CheckOut = new DateOnly(2026, 12, 20),
                GuestId = 2,
                RoomId = 2
            };

            var result = await sut.UpdateBookingAsync(9999, updateRequest);

            Assert.Null(result);
        }
    }
}
