using BookingApp.API.DTOs.Hotels;
using BookingApp.API.Services.HotelServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/hotel")]

    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<HotelResponseDto>> CreateHotel([FromBody] CreateHotelRequestDto hotelRequest)
        {
            var response = await _hotelService.CreateHotelAsync(hotelRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<HotelResponseDto>>> GetHotels()
        {
            var response = await _hotelService.GetHotelsAsync();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HotelResponseDto?>> GetHotelById(int id)
        {
            var response = await _hotelService.GetHotelByIdAsync(id);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotelByIdAsync(int id)
        {
            var response = await _hotelService.DeleteHotelByIdAsync(id);
            if (response) return NoContent();
            return NotFound();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<HotelResponseDto>> UpdateHotelAsync(int id, [FromBody] UpdateHotelRequestDto hotelRequest)
        {
            var response = await _hotelService.UpdateHotelAsync(id, hotelRequest);
            if (response == null) return NotFound();
            return Ok(response);
        }
    }
}