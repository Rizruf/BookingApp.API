using BookingApp.API.DTOs.Guests;
using BookingApp.API.Services.GuestService;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/guests")]

    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        { 
            _guestService = guestService;
        }

        [HttpPost]
        public async Task<ActionResult<GuestResponseDto>> CreateGuest([FromBody] CreateGuestRequestDto guestRequest)
        {
            var response = await _guestService.CreateGuestAsync(guestRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<GuestResponseDto>>> GetGuests()
        {
            var response = await _guestService.GetGuestsAsync();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestResponseDto?>> GetGuestById(int id)
        {
            var response = await _guestService.GetGuestByIdAsync(id);
            if (response == null) return NotFound();
            return response;
        }
    }
}
