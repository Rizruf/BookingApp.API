using BookingApp.API.DTOs.Rooms;
using BookingApp.API.Services.RoomServices;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<ActionResult<RoomResponseDto>> CreateRoom([FromBody] CreateRoomRequestDto roomRequest)
        {
            var response = await _roomService.CreateRoomAsync(roomRequest);
            return Ok(response);
        }
    }
}
