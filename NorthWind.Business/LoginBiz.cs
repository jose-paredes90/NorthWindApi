using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NorthWind.Dto;
using NorthWind.Dto.Request;
using NorthWind.Entity.Models;
using NorthWind.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NorthWind.Business
{
    public class LoginBiz : ILoginBiz
    {
        private readonly NorthwindContext northwindContext;
        private readonly IConfiguration configuration;
        public LoginBiz(NorthwindContext context, IConfiguration configuration)
        {
            northwindContext = context;
            this.configuration = configuration;
        }
        public LoginDto Login(LoginRequest login)
        {
            Usuarios user = northwindContext.Usuarios
                    .FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
            if (user != null)
            {
                return new LoginDto()
                {
                    AccessToken = GenerateJSONWebToken(user)
                };
            }

            return null;
        }

        private string GenerateJSONWebToken(Usuarios user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim("employeesId", user.EmployeesId.ToString()),
            new Claim("userId", user.UserId.ToString())
            };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
