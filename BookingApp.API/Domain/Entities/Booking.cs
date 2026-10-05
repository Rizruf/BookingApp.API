using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; init; }

        public DateOnly CheckIn { get; private set; }
        public DateOnly CheckOut { get; private set; }

        public int GuestId { get; private set; }
        public Guest? Guest { get; private set; }
        public int RoomId { get; private set; }
        public Room? Room { get; private set; }

        public Booking(DateOnly checkIn, DateOnly checkOut, int guestId, int roomId)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            GuestId = guestId;
            RoomId = roomId;
        }
    }
}
