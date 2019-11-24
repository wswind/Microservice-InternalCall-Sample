using api2.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public List<UserInfoDto> GetUsers()
        {
            return new List<UserInfoDto>
            {
                new UserInfoDto{Id = 1,Name="zz" },
                new UserInfoDto{Id = 1,Name="aa" },
                new UserInfoDto{Id = 1,Name="bb" }
            };
        }
    }
}