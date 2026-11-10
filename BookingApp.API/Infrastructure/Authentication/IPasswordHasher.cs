using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Authentication
{
    public interface IPasswordHasher
    {
        string Generate(string password);
        bool Verify(string password, string hashedPassword);
    }
}
