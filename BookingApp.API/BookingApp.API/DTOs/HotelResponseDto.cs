using System.ComponentModel.DataAnnotations;

namespace BookingApp.API.DTOs
{
    public class HotelResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
