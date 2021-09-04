using fabiostefani.io.CleanArch.Domain.entities;

namespace fabiostefani.io.CleanArch.Domain.service
{
    public class NovemberTaxCalculator : TaxCalculator
    {
        public override decimal GetTaxes(List<TaxTable> taxTables)
        {
            TaxTable taxTable = taxTables.Find(taxTable => taxTable.Type.Equals("november", StringComparison.InvariantCultureIgnoreCase));
            if (taxTable == null) return 0;
            return taxTable.Value;
        }
    }
}