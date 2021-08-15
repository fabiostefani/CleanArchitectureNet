using System;
using System.Collections.Generic;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;

namespace fabiostefani.io.CleanArch.Repository
{
    public class CouponRepositoryMemory : ICouponRepository
    {
        private readonly List<Coupon> Coupons;
        public CouponRepositoryMemory()
        {
            Coupons = new List<Coupon>(){
                new Coupon("VALE-20", 20, DateTime.Now),
                new Coupon("VALE-20-EXPIRED", 20, new DateTime(2020, 01, 01))
            };
        }
        public Coupon? GetByCode(string code)
        {
            return Coupons.Find(coupon => coupon.Code == code);
        }
    }
}