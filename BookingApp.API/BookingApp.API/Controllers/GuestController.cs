using BookingApp.API.DTOs.Guests;
using BookingApp.API.DTOs.Hotels;
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuestByIdAsync(int id)
        {
            var response = await _guestService.DeleteGuestByIdAsync(id);
            if (response) return NoContent();
            return NotFound();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GuestResponseDto>> UpdateGuestasync(int id, [FromBody] UpdateGuestRequestDto guestRequest)
        {
            var response = await _guestService.UpdateGuestAsync(id, guestRequest);
            if (response == null) return NotFound();
            return Ok(response);
        }
    }
}
