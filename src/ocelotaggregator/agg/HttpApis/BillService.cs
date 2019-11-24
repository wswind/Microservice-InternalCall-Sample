using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api1.Dtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace agg.HttpApis
{
    public class BillService : IBillService
    {
        private readonly HttpClient _httpClient;
        private readonly string _gatewayUrl;

        public BillService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _gatewayUrl = configuration.GetValue<string>("GatewayUrl");
        }

        public async Task<List<BillDto>> GetBills()
        {
            var data = await _httpClient.GetStringAsync($"{_gatewayUrl}/api1/bill");
            var bills = !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<List<BillDto>>(data) : null;
            return bills;
           
        }
    }
}
