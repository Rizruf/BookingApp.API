using BookingApp.API.DTOs.Rooms;

namespace BookingApp.API.Services.RoomServices
{
    public interface IRoomService
    {
        Task<RoomResponseDto> CreateRoomAsync(CreateRoomRequestDto requestRoom);
    }
}
