using BookingApp.API.DTOs;
using BookingApp.API.Services; // Подключаем сервисы
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequestDto request)
        {
            // Контроллер просто передает данные в сервис
            var newRoom = await _roomService.CreateRoomAsync(request);
            return Ok(newRoom);
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomService.GetRoomsAsync();
            return Ok(rooms);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] CreateRoomRequestDto request)
        {
            var updatedRoom = await _roomService.UpdateRoomAsync(id, request);

            if (updatedRoom == null)
            {
                return NotFound(new { Message = $"Комната с ID {id} не найдена" });
            }

            return Ok(updatedRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var isDeleted = await _roomService.DeleteRoomAsync(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = $"Комната с ID {id} не найдена" });
            }

            return Ok(new { Message = $"Комната с ID {id} успешно удалена" });
        }

    }
}