using fabiostefani.io.CleanArch.Domain.entities;

namespace fabiostefani.io.CleanArch.Domain.service
{
    public abstract class TaxCalculator
    {
        public abstract decimal GetTaxes(List<TaxTable> taxTables);
        public decimal Calculate(Item item, List<TaxTable> taxTables)
        {
            return (item.Price * GetTaxes(taxTables) ) / 100;                
        }
    }
}