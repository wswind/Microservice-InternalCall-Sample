using api2.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace agg.HttpApis
{
    public interface IUserService 
    {
        Task<List<UserInfoDto>> GetUsers();
    }
}
