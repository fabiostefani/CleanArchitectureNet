using fabiostefani.io.CleanArch.Domain.entities;
using fabiostefani.io.CleanArch.Domain.service;
using Xunit;

namespace fabiostefani.io.CleanArch.DomainTests
{
    public class StockCalculatorTests
    {
        [Fact]
        public void Calculate_DeveCalcularEstoqueDeUmItem()
        {
            var stockeEntries = new List<StockEntry> (){
                new StockEntry(1, "in", 3, DateTime.Now),
                new StockEntry(1, "out", 2, DateTime.Now),
                new StockEntry(1, "in", 2, DateTime.Now),
            };
            var stockCalculator = new StockCalculator();
            decimal quantity = stockCalculator.Calculate(stockeEntries);
            Assert.Equal(3, quantity);
        }
    }
}