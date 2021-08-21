using System;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;
using fabiostefani.io.CleanArch.Repository.database;
using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;

namespace fabiostefani.io.CleanArch.Repository.Repository.Database
{
    public class CouponRepositoryDatabase : ICouponRepository
    {
        private readonly IDatabase database;
        public CouponRepositoryDatabase(IDatabase database)
        {
            this.database = database;

        }
        public async Task<Coupon?> GetByCode(string code)
        {
            CoupomEf coupomEf = await this.database.One<CoupomEf>(x => x.Code == code);            
            if (coupomEf == null)
            {
                throw new Exception($"Coupon not found by Code {code}");
            }
            return new Coupon(coupomEf.Code, coupomEf.Percentage, coupomEf.ExpireDate);
        }
    }
}