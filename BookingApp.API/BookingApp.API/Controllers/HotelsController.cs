using BookingApp.API.DTOs.Hotels;
using BookingApp.API.Services.HotelServices;
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
        public async Task<ActionResult<HotelResponseDto>> CreateHotel([FromBody] CreateHotelRequestDto hotelRequest)
        {
            var response = await _hotelService.CreateHotelAsync(hotelRequest);
            return Ok(response);
        }
    }
}