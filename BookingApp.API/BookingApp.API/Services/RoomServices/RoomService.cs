using BookingApp.API.DTOs.Rooms;
using Domain.Entities;
using Infrastructure;

namespace BookingApp.API.Services.RoomServices
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RoomResponseDto> CreateRoomAsync(CreateRoomRequestDto requestRoom)
        {
            var room = new Room(
                type: requestRoom.Type,
                price: requestRoom.Price,
                description: requestRoom.Description,
                sleepingPlaces: requestRoom.SleepingPlaces,
                hotelId: requestRoom.HotelId
                );

            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();

            return new RoomResponseDto
            {
                Id = room.Id,
                Type = room.Type,
                Price = room.Price,
                Description = room.Description,
                SleepingPlaces = room.SleepingPlaces,
                HotelId = room.HotelId
            };
        }
    }
}
