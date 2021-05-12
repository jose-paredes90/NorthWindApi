using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using NorthWind.Dto;
using NorthWind.Interfaces.Business;
using NorthWind.Dto.Request;

namespace NorthWind.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginBiz loginBiz;

        public AuthController(ILoginBiz loginBiz)
        {
            this.loginBiz = loginBiz;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            LoginDto token = loginBiz.Login(login);

            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
       
    }
}
