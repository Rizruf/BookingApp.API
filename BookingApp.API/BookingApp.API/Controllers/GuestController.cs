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
            var responce = await _guestService.CreateGuestAsync(guestRequest);
            return Ok(responce);
        }
    }
}
