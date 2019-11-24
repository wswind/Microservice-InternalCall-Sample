using api2.Dtos;
using System.Collections.Generic;
using WebApiClient;
using WebApiClient.Attributes;

namespace agg.HttpApis
{
    public interface IUserService : IHttpApi
    {
        [HttpGet("api2/User")]
        ITask<List<UserInfoDto>> GetUsers();
    }
}
