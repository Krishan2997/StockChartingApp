using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Entities;
using User.Api.Models;

namespace User.Api.Repository
{
    public interface IUsersRepository
    {
        public ActionResult<Response> UserLogIn(UsersModel user);
        public ActionResult<Response> UserSignUp(Users user);
        public ActionResult<Response> AdminLogIn(UsersModel admin);
        public ActionResult<Response> LogOut(LogoutModel admin);

        //
        public ActionResult<Response> Try(Users user);

    }
}
