using BookingApp.API.Data;
using BookingApp.API.DTOs;
using BookingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Services
{
    public class RoomService : IRoomService
    {
        private readonly BookingDbContext _context;

        public RoomService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<Room> CreateRoomAsync(CreateRoomRequestDto request)
        {
            var newRoom = new Room
            {
                Title = request.Title,
                PricePerNight = request.PricePerNight,
                HotelId = request.HotelId
            };

            await _context.Rooms.AddAsync(newRoom);
            await _context.SaveChangesAsync();

            return newRoom;
        }

        public async Task<IEnumerable<RoomsResponseDto>> GetRoomsAsync()
        {
            return await _context.Rooms
                .Select(r => new RoomsResponseDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    PricePerNight = r.PricePerNight,
                    HotelTitle = r.Hotel.Title
                }).ToListAsync();
        }

        public async Task<Room?> UpdateRoomAsync(int id, CreateRoomRequestDto request)
        {
            var existingRoom = await _context.Rooms.FindAsync(id);

            if (existingRoom == null) return null; // Если не нашли, возвращаем пустоту

            // Обновляем данные
            existingRoom.Title = request.Title;
            existingRoom.PricePerNight = request.PricePerNight;
            existingRoom.HotelId = request.HotelId;

            await _context.SaveChangesAsync();
            return existingRoom;
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            var existingRoomDel = await _context.Rooms.FindAsync(id);

            if (existingRoomDel == null) return false; // Если не нашли, удалять нечего

            _context.Rooms.Remove(existingRoomDel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}