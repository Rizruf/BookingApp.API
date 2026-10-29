using BookingApp.API.DTOs.Rooms;
using BookingApp.API.Services.RoomServices;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/rooms")]

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

        [HttpGet]
        public async Task<ActionResult<List<RoomResponseDto>>> GetRooms()
        {
            var response = await _roomService.GetRoomsAsync();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomResponseDto?>> GetRoomById(int id)
        {
            var response = await _roomService.GetRoomByIdAsync(id);
            if (response == null) return NotFound();
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoomByIdAsync (int id)
        {
            var response = await _roomService.DeleteRoomByIdAsync(id);
            if (response) return NoContent();
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoomResponseDto>> UpdateRoomAsync (int id,[FromBody] UpdateRoomRequestDto roomRequest)
        {
            var response = await _roomService.UpdateRoomAsync(id, roomRequest);
            if (response == null) return NotFound();
            return Ok(response);
        }

    }
}
