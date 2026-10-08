using Domain.Enums;

namespace BookingApp.API.DTOs.Guests
{
    public class CreateGuestRequestDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string PhoneNumber { get; set; }
        public required Gender Gender { get; set; }
    }
}
