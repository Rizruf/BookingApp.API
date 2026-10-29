using BookingApp.API.DTOs.Rooms;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<RoomResponseDto>> GetRoomsAsync()
        {
            var rooms = await _context.Rooms
                              .Select(room => new RoomResponseDto
                              {
                                  Id = room.Id,
                                  Type = room.Type,
                                  Price = room.Price,
                                  Description = room.Description,
                                  SleepingPlaces = room.SleepingPlaces,
                                  HotelId = room.HotelId

                              }).ToListAsync();

            return rooms;
        }

        public async Task<RoomResponseDto?> GetRoomByIdAsync(int id)
        {
            var room = await _context.Rooms
                             .Select(room => new RoomResponseDto
                             {
                                 Id = room.Id,
                                 Type = room.Type,
                                 Price = room.Price,
                                 Description = room.Description,
                                 SleepingPlaces = room.SleepingPlaces,
                                 HotelId = room.HotelId

                             }).FirstOrDefaultAsync(x => x.Id == id);
            return room;
        }

        public async Task<bool> DeleteRoomByIdAsync(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (room == null) return false;

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<RoomResponseDto?> UpdateRoomAsync(int id, UpdateRoomRequestDto requestUpdateRoom)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (room == null) return null;

            room.Update(
                requestUpdateRoom.Type,
                requestUpdateRoom.Price,
                requestUpdateRoom.Description,
                requestUpdateRoom.SleepingPlaces,
                requestUpdateRoom.HotelId
                );

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
