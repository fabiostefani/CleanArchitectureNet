using fabiostefani.io.CleanArch.Domain;
using Xunit;

namespace fabiostefani.io.CleanArch.DomainTests
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