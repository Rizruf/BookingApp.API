using BookingApp.API.DTOs;
using BookingApp.API.Models;

namespace BookingApp.API.Services
{
    public interface IRoomService
    {
        Task<Room> CreateRoomAsync(CreateRoomRequestDto request);
        Task<IEnumerable<RoomsResponseDto>> GetRoomsAsync();

        Task<Room?> UpdateRoomAsync(int id, CreateRoomRequestDto request);
        Task<bool> DeleteRoomAsync(int id);
    }
}