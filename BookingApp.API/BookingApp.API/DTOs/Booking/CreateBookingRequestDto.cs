namespace BookingApp.API.DTOs.Booking
{
    public class CreateBookingRequestDto
    {
        public required DateOnly CheckIn { get; set; }
        public required DateOnly CheckOut { get; set; }
        public required int GuestId { get; set; }
        public required int RoomId { get; set; }
    }
}
