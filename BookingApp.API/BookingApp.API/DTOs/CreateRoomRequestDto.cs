using System.ComponentModel.DataAnnotations;

namespace BookingApp.API.DTOs
{
    public class CreateRoomRequestDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [Range(100, 1000000)]
        public decimal PricePerNight { get; set; }

        [Range(1, int.MaxValue)]
        public int HotelId { get; set; }
    }
}
