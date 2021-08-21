using System;
using fabiostefani.io.CleanArch.Domain.entities;
using Xunit;

namespace fabiostefani.io.CleanArch.DomainTests
{
    public class OrderCodeTests
    {
        [Fact]
        public void OrderCode_DeveGerarCodigo_CotendoAnoComSequencia()
        {
            var orderCode = new OrderCode(DateTime.Now, 1);
            Assert.Equal("202100000001", orderCode.Value);
            orderCode = new OrderCode(new DateTime(2020,10,02) , 10);
            Assert.Equal("202000000010", orderCode.Value);
        }
    }
}