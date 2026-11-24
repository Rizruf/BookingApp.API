using BookingApp.API.DTOs.Guests;
using BookingApp.API.DTOs.Hotels;
using BookingApp.API.DTOs.Rooms;

namespace BookingApp.API.Services.RoomServices
{
    public interface IRoomService
    {
        Task<RoomResponseDto> CreateRoomAsync(CreateRoomRequestDto requestRoom);
        Task<List<RoomResponseDto>> GetRoomsAsync();
        Task<RoomResponseDto?> GetRoomByIdAsync(int id);
        Task<bool> DeleteRoomByIdAsync(int id);
        Task<RoomResponseDto?> UpdateRoomAsync(int id, UpdateRoomRequestDto requestUpdateRoom);
    }
}
