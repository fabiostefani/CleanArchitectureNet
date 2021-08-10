using System;
using fabiostefani.io.CleanArch.Domain;
using Xunit;

namespace fabiostefani.io.CleanArch.DomainTests
{
    public class CouponTests
    {
        [Fact]
        public void DeveVerificarSeOCupomEstaExpirado()
        {
            var coupon = new Coupon("VALE-20", 20, new DateTime(2020,01,01));
            Assert.True(coupon.IsExpired());
        }
    }
}