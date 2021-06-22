using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using User.Api.DbContexts;
using User.Api.Entities;
using User.Api.Models;
using User.Api.Repository;

namespace User.Api
{
    public class Authentication:IAuthentication
    {
        private UsersContext _context;
        public Authentication(UsersContext context)
        {
            _context = context;
        }

        public bool checkUser(UsersModel user)
        {
            var realUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (realUser != null)
            {
                //var hashPass = user.Password.GetHashCode().ToString();
                if (realUser.Password == user.Password)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public string validateUser(Users user)
        {
            var userNameValidation = Regex.IsMatch(user.UserName, @"^[A-Z]{2}$");
            if (!userNameValidation)
            {
                return this.GenerateJSONWebToken(user.UserName);
            }
            return "Enter valid username";
        }

        private string GenerateJSONWebToken(string username)
        {
            string key = "this is my key for authntication";
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}