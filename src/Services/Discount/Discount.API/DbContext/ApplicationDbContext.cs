using Dapper;
using Discount.API.IRepository;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.DbContext
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        private readonly IDbConnection _dbContext;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _dbContext = new NpgsqlConnection(configuration.GetConnectionString("DiscountDb"));
        }

        public async Task<int> AddAsync(string command, object parms)
        {
            return await _dbContext.ExecuteAsync(command, parms);
        }

        public async Task<int> DeleteAsync(string command, object parms)
        {
            return await _dbContext.ExecuteAsync(command, parms);
        }

        public async Task<List<T>> GetAllAsync<T>(string command, object parms)
        {
            return (await _dbContext.QueryAsync<T>(command, parms)).ToList();
        }

        public async Task<T> GetByIdAsync<T>(string command, object parms)
        {
            return (await _dbContext.QueryAsync<T>(command, parms)).FirstOrDefault();
        }

        public async Task<int> UpdateAync(string command, object parms)
        {
            return await _dbContext.ExecuteAsync(command, parms);
        }
    }
}
