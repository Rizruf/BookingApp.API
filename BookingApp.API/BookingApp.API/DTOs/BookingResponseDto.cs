using BookingApp.API.Models;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.API.DTOs
{
    public class BookingResponseDto
    {
        public int Id { get; set; }
        public string GuestName { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
