﻿using WebApiClient;
using WebApiClient.Attributes;

namespace api1.Services
{
    public interface ICallService : IHttpApi
    {
        [HttpGet("api2/Double")]
        ITask<int> GetDouble(int i);
    }
}
