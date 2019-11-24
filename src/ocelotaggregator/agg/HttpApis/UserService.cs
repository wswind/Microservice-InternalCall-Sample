using api2.Dtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace agg.HttpApis
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _gatewayUrl;

        public UserService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _gatewayUrl = configuration.GetValue<string>("GatewayUrl");
        }
        public async Task<List<UserInfoDto>> GetUsers()
        {
            var data = await _httpClient.GetStringAsync($"{_gatewayUrl}/api2/user");
            var users = !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<List<UserInfoDto>>(data) : null;
            return users;
        }
    }
}
