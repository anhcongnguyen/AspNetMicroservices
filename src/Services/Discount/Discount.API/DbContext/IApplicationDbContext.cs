using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.API.IRepository
{
    public interface IApplicationDbContext
    {
        Task<T> GetByIdAsync<T>(string command, object parms);
        Task<List<T>> GetAllAsync<T>(string command, object parms);
        Task<int> AddAsync(string command, object parms);
        Task<int> UpdateAync(string command, object parms);
        Task<int> DeleteAsync(string command, object parms);
    }
}
