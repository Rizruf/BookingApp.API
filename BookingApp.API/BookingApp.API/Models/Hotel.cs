namespace BookingApp.API.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Room> Rooms { get; set; } = new();
    }
}
