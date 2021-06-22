using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.DbContexts;
using User.Api.Entities;
using User.Api.Models;

namespace User.Api.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private UsersContext _context;
        private IAuthentication _localAuth;
        public UsersRepository(UsersContext context, IAuthentication localAuth)
        {
            _context = context;
            _localAuth = localAuth;
        }

        public ActionResult<Response> AdminLogIn(UsersModel admin)
        {
            var response = new Response();
            response.code = 0;
            var logger = _context.Users.FirstOrDefault(u => u.UserName == admin.UserName);
            if (logger!=null && logger.UserType.ToLower() == "user")
            {
                response.token = "LogIn with User";
            }
            else
            {
                var pres = _context.LoggedInUsers.FirstOrDefault(u => u.UserName == admin.UserName);
                if (pres == null)
                {
                    if (_localAuth.checkUser(admin))
                    {
                        var token = _localAuth.validateUser(logger);
                        _context.LoggedInUsers.Add(new LoggedInUsers() { UserName = admin.UserName , token=token});
                        _context.SaveChanges();
                        response.code = 1;
                        response.token = token;
                    }
                    else
                    {
                        response.token = "Check Password";
                    }
                }
                else
                {
                    response.token = pres.token;
                }
            }
            return response;
        }

        public ActionResult<Response> LogOut(LogoutModel user)
        {
            var response = new Response();
            response.code = 0;
            var pres = _context.LoggedInUsers.FirstOrDefault(u => u.UserName == user.userName);
            if (pres != null)
            {
                _context.LoggedInUsers.Remove(pres);
                _context.SaveChanges();
                response.code = 1;
                response.token = "Log Out Success";
            }
            else
            {
                response.token = "You are not LoggedIn";
            }
            return response;
        }

        public ActionResult<Response> UserLogIn(UsersModel user)
        {
            var response=new Response();
            response.code = 0;
            var logger = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (logger == null)
            {
                response.token = "You need to signUp";
                return response;
            }
            if (logger.UserType.ToLower() == "admin")
            {
                response.token = "LogIn with Admin";
                return response;
            }
            var pres = _context.LoggedInUsers.FirstOrDefault(u => u.UserName == user.UserName);
            if (pres == null)
            {
                if (_localAuth.checkUser(user))
                {
                    var token = _localAuth.validateUser(logger);
                    _context.LoggedInUsers.Add(new LoggedInUsers() { UserName = user.UserName , token=token});
                    _context.SaveChanges();
                    response.code = 1;
                    response.token = token;
                    return response;
                }
                response.token = "Not valid";
                return response;
            }
            response.token = pres.token;
            return response;
        }

        public ActionResult<Response> UserSignUp(Users user)
        {
            var response = new Response();
            response.code = 0;
            var token = _localAuth.validateUser(user);
            if (token!= "Enter valid username")
            {
                if (user.UserType.ToLower() == "user")
                {
                    //user.Password = user.Password.GetHashCode().ToString();
                    _context.Add(user);
                    _context.SaveChanges();
                    response.code = 1;
                    response.token = token;
                    return response;
                }
                response.token = "You can not sign up as admin";
                return response;
            }
            response.token = "Not valid details";
            return response;
        }

        public ActionResult<Response> Try(Users user)
        {
            throw new NotImplementedException();
        }

    }
}