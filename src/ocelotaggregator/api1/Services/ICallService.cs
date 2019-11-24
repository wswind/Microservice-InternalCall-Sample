using System.Threading.Tasks;

namespace api1.Services
{
    public interface ICallService 
    {
        Task<int> GetDouble(int i);
    }
}
