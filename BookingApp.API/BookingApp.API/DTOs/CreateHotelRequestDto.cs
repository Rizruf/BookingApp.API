using System.ComponentModel.DataAnnotations;

namespace BookingApp.API.DTOs
{
    public class CreateHotelRequestDto
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
