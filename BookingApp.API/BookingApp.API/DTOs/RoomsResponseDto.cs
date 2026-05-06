using BookingApp.API.Models;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.API.DTOs
{
    public class RoomsResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
    }
}
