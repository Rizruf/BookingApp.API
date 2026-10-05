namespace Domain.Entities
{
    public class Hotel
    {
        public int Id { get; init; }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public double Rating { get; private set; }
        public string Address { get; private set; }

        public List<Room> Rooms { get; private set; } = new();

        public Hotel(string title, string description, double rating, string address)
        {
            Title = title;
            Description = description;
            Rating = rating;
            Address = address;
        }
    }
}
