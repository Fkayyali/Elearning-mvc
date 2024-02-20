using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Models;

namespace Service
{
    public interface ITokenService
    {
        string CreateToken(User user);
        bool IsTokenValid(string token);
        int GetUserId(string token);
    }
}