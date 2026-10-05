using BookingApp.API.DTOs.Hotels;
using BookingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<ActionResult<HotelResponseDto>> CreateHotel([FromBody] CreateHotelRequestDto request)
        {
            var response = await _hotelService.CreateHotelAsync(request);
            return Ok(response);
        }
    }
}