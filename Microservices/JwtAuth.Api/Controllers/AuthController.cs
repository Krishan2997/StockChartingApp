using JwtAuth.Api.Models;
using JwtAuth.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        //[AllowAnonymous]
        public IActionResult Authenticate(UserModel user)
        {
            var res=_repo.Auther(user.username, user.password);
            if (res == null) return Unauthorized();
            return Ok(res);
        }
    }
}
