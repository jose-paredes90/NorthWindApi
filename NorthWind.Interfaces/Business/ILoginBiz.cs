using NorthWind.Dto;
using NorthWind.Dto.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Interfaces.Business
{
    public interface ILoginBiz
    {
        LoginDto Login(LoginRequest login);
    }
}
