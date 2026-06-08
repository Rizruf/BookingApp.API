using BookingApp.API.DTOs;
using BookingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);

            if (hotel == null)
            {
                return NotFound(new { Message = $"Отель с ID {id} не найден" });
            }

            return Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelRequestDto request)
        {
            var newHotel = await _hotelService.CreateHotelAsync(request);
            return Ok(newHotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] CreateHotelRequestDto request)
        {
            var updatedHotel = await _hotelService.UpdateHotelAsync(id, request);

            if (updatedHotel == null)
            {
                return NotFound(new { Message = $"Отель с ID {id} не найден" });
            }

            return Ok(updatedHotel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var isDeleted = await _hotelService.DeleteHotelAsync(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = $"Отель с ID {id} не найден" });
            }

            return Ok(new { Message = "Отель успешно удален" });
        }
    }
}