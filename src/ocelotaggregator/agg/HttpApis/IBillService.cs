using api1.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace agg.HttpApis
{
    public interface IBillService 
    {
        Task<List<BillDto>> GetBills();
    }


}
