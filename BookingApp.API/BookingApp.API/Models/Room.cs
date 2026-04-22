using System.Runtime.ConstrainedExecution;

namespace BookingApp.API.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
