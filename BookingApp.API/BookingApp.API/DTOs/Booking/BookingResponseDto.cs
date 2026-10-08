namespace BookingApp.API.DTOs.Booking
{
    public class BookingResponseDto
    {
        public int Id { get; init; }
        public required DateOnly CheckIn { get; set; }
        public required DateOnly CheckOut { get; set; }
        public required int GuestId { get; set; }
        public required int RoomId { get; set; }
    }
}
