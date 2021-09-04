using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.entities;
using fabiostefani.io.CleanArch.Domain.Factory;
using Xunit;

namespace fabiostefani.io.CleanArch.DomainTests
{
    public class TaxCalculatorTest
    {
        [Fact]
        public void TaxCalculator_DeveCalcularImpostoDeUmItemGuitarra_ParaMesesNormais()
        {
            var item = new Item("1", "Guitarra", 1000, 100, 50, 30, 10);
            var taxTables = new List<TaxTable> { new TaxTable("1", "default", 15), new TaxTable("1", "november", 5) };
            var data = new DateTime(2021, 10, 10);
            var taxCalculator = TaxCalculatorFactory.Create(data);
            var amount = taxCalculator.Calculate(item, taxTables);
            Assert.Equal(150, amount);
        }

        [Fact]
        public void TaxCalculator_DeveCalcularImpostoDeUmItemGuitarra_NoMesDeNovembro()
        {
            var item = new Item("1", "Guitarra", 1000, 100, 50, 30, 10);
            var taxTables = new List<TaxTable> { new TaxTable("1", "default", 15), new TaxTable("1", "november", 5) };
            var data = new DateTime(2021, 11, 10);
            var taxCalculator = TaxCalculatorFactory.Create(data);
            var amount = taxCalculator.Calculate(item, taxTables);
            Assert.Equal(50, amount);
        }

        [Fact]
        public void TaxCalculator_DeveCalcularImpostoDeUmItemCabo_ParaMesesNormais()
        {
            var item = new Item("3", "Cabo", 30, 10, 10, 10, 1);
            var taxTables = new List<TaxTable> { new TaxTable("3", "default", 5), new TaxTable("3", "november", 1) };
            var data = new DateTime(2021, 10, 10);
            var taxCalculator = TaxCalculatorFactory.Create(data);
            var amount = taxCalculator.Calculate(item, taxTables);
            Assert.Equal(1.5m, amount);
        }

        [Fact]
        public void TaxCalculator_DeveCalcularImpostoDeUmItemCabo_NoMesDeNovembro()
        {
            var item = new Item("3", "Cabo", 30, 10, 10, 10, 1);
            var taxTables = new List<TaxTable> { new TaxTable("3", "default", 5), new TaxTable("3", "november", 1) };
            var data = new DateTime(2021, 11, 10);
            var taxCalculator = TaxCalculatorFactory.Create(data);
            var amount = taxCalculator.Calculate(item, taxTables);
            Assert.Equal(0.3m, amount);
        }
    }
}