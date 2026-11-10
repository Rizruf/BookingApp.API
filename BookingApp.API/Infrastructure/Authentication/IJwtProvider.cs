using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Authentication
{
    public interface IJwtProvider
    {
        string GenerateToken(Domain.Entities.User user);
    }
}
