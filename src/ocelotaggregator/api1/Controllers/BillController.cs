using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api1.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        public List<BillDto> GetBills()
        {
            var dtos = new List<BillDto>
            {
                new BillDto {Id=1,Data="80",UserId=1 },
                new BillDto {Id=2,Data="90",UserId=2 },
                new BillDto {Id=3,Data="100",UserId=3 }
            };
            return dtos;
        }
    }
}