using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Entities;
using User.Api.Models;
using User.Api.Repository;

namespace User.Api.Controllers
{
    [EnableCors("CORS-Enabler")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersRepository _repo;

        public UsersController(IUsersRepository repo)
        {
            _repo = repo;
        }


        [HttpPost("/user/login")]
        public ActionResult<Response> UserLogIn(UsersModel user)
        {
            return _repo.UserLogIn(user);
        }

        [HttpPost("/admin/login")]
        public ActionResult<Response> AdminLogIn(UsersModel admin)
        {
            return _repo.AdminLogIn(admin);
        }

        [HttpPost("/logout")]
        //[Authorize]
        public ActionResult<Response> UserLogOut(LogoutModel user)
        {
            return _repo.LogOut(user);
        }

        [HttpPost("/signup")]
        public ActionResult<Response> SignUp(Users user)
        {
            return _repo.UserSignUp(user);
        }
    }
}
