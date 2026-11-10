using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public int  Id { get; init; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }

        public User(string passwordHash, string email, string role)
        {
            PasswordHash = passwordHash;
            Email = email;
            Role = role;
        }
    }
}
