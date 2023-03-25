using Discount.API.DbContext;
using Discount.API.Entities;
using Discount.API.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly IApplicationDbContext _dbcontext;
        public CouponRepository(IApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(Coupon coupon)
        {
            var result = await _dbcontext.AddAsync("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
            if (result == 0)
                return false;
            return true;
        }

        public async Task<bool> DeleteAsync(string productName)
        {
            var result = await _dbcontext.DeleteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = productName });
            if (result == 0)
                return false;
            return true;
        }

        public async Task<List<Coupon>> GetAllAsync()
        {
            var coupons = await _dbcontext.GetAllAsync<Coupon>("SELECT * FROM Coupon", new { });
            return coupons;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            var coupon = await _dbcontext.GetByIdAsync<Coupon>("SELECT * FROM Coupon WHERE productName = @productName", new { productName });
            if (coupon == null)
                return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
            return coupon;
        }

        public async Task<bool> UpdateAync(Coupon coupon)
        {
            var result = await _dbcontext.UpdateAync("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                            new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });
            if (result == 0)
                return false;
            return true;
        }
    }
}
