using fabiostefani.io.CleanArch.Domain;
using Xunit;

namespace fabiostefani.io.CleanArch.DomainTests
{
    public class ItemTest
    {
        [Fact]
        public void DeveCalcularOVolumeDeUmItem()
        {
            var item = new Item("1", "Amplificador", 5000, 50, 50, 50, 22);
            decimal volume = item.GetVolume();
            Assert.Equal(0.125m, volume);
        }

        [Fact]
        public void DeveCalcularADensidadeDeUmItem()
        {
            var item = new Item("1", "Amplificador", 5000, 50, 50, 50, 22);
            decimal density = item.GetDensity();
            Assert.Equal(176, density);
        }
    }
}