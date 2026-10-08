namespace BookingApp.API.DTOs.Rooms
{
    public class RoomResponseDto
    {
        public required int Id { get; init; }
        public required string Type { get; set; }
        public required decimal Price { get; set; }
        public required string Description { get; set; }
        public required int SleepingPlaces { get; set; }
        public required int HotelId { get; set; }
    }
}
