﻿using System.Collections.Generic;
using System.Security.Claims;

namespace EquinoxCore.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
