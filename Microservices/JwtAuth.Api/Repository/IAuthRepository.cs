using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuth.Api.Repository
{
    public interface IAuthRepository
    {
        string Auther(string username, string password);
    }
}
