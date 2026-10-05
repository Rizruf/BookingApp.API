using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Guest
    {
        public int Id { get; init; }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }

        public Guest(string name, string surname, string phoneNumber, Gender gender)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }
    }
}
