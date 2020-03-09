using FlightSchedule.Application.Interfaces;
using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Models;
using FlightSchedule.Domain.Models.Response;
using FlightSchedule.Infra.CrossCutting.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchedule.Application
{
    public class AuthAppService : IAuthAppService
    {
        private readonly string _role = "administrator";
        public Task<Result<UserResponse>> GenerateToken(User user)
        {
            if (user.Login != "admin" || user.Password != "123456")
                return Task.FromResult(new Result<UserResponse>(null, HttpStatusCode.Unauthorized, problemTittle: "Login or password invalid"));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Setting.SecretJWT);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, _role)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userResponse = new UserResponse
            {
                Login = user.Login,
                Token = tokenHandler.WriteToken(token)
            };
            return Task.FromResult(new Result<UserResponse>(userResponse, HttpStatusCode.OK));
        }
    }
}
