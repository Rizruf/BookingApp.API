using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Room
    {

        public int Id { get; init; }

        public string Type { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public int SleepingPlaces { get; private set; }

        public Hotel? Hotel { get; private set; }
        public int? HotelId { get; private set; }

        public Room(string type, decimal price, string description, int sleepingPlaces)
        {
            if (sleepingPlaces < 1 || sleepingPlaces > 10)
                throw new ArgumentOutOfRangeException(nameof(sleepingPlaces), "Количество мест должно быть от 1 до 10.");

            Type = type;
            Price = price;
            Description = description;
            SleepingPlaces = sleepingPlaces;
        }
    }
}
