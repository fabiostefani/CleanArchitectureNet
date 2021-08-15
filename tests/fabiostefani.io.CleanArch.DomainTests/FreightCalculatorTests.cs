using fabiostefani.io.CleanArch.Domain;
using Xunit;

namespace fabiostefani.io.CleanArch.DomainTests
{
    public class FreightCalculatorTests
    {
        [Fact]
        public void DeveCalcularOFreteDoAmplificador()
        {
            var item = new Item("2", "Amplificador", 5000, 50, 50, 50, 22);
            var distance = 1000;
            decimal price = FreightCalculator.Calculate(distance, item);
            Assert.Equal(220, price);
        }

        [Fact]
        public void DeveCalcularOFreteDaGuitarra()
        {
            var item = new Item("1", "Guitarra", 1000, 100, 50, 15, 3);
            var distance = 1000;
            decimal price = FreightCalculator.Calculate(distance, item);
            Assert.Equal(30, price);
        }

        [Fact]
        public void DeveCalcularOFreteDoCabo()
        {
            var item = new Item("3", "Cabo", 30, 9, 9, 9, 0.1m);
            var distance = 1000;
            decimal price = FreightCalculator.Calculate(distance, item);
            Assert.Equal(10, price);
        }
    }
}