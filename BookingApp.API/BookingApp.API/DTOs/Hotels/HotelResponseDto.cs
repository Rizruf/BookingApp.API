namespace BookingApp.API.DTOs.Hotels
{
    public class HotelResponseDto
    {
        public int Id { get; init; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required double Rating { get; set; }
        public required string Address { get; set; }
    }
}
