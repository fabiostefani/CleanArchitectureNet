using System;
using fabiostefani.io.CleanArch.Gateway.memory;
using Xunit;

namespace fabiostefani.io.CleanArch.GatewayTests
{    
        public class ZipCodeCalculatorTests
    {
        [Fact]
        public void DeveCalcularADistanciaEntreDoisCeps()
        {
            var zipCodeCalculatorApi = new ZipCodeCalculatorApiMemory();
            int distance = zipCodeCalculatorApi.Calculate("11.111-111", "99.999-99");
            Assert.Equal(1000, distance);
        }
    }
    
}
