using System.ComponentModel.DataAnnotations;

namespace BookingApp.API.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string GuestName { get; set; } = string.Empty;

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }
        
        public int RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
