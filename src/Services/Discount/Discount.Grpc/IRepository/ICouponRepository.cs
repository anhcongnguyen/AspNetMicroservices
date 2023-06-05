using Discount.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.IRepository
{
    public interface ICouponRepository 
    {
        Task<Coupon> GetDiscount(string ProductName);
        Task<List<Coupon>> GetAllAsync();
        Task<bool> AddAsync(Coupon coupon);
        Task<bool> UpdateAync(Coupon coupon);
        Task<bool> DeleteAsync(string ProductName);
    }
}
