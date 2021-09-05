using System;
using System.Collections.Generic;
using fabiostefani.io.CleanArch.Domain.entities;

namespace fabiostefani.io.CleanArch.Domain.service
{
    public class DefaultTaxCalculator : TaxCalculator
    {
        public override decimal GetTaxes(List<TaxTable> taxTables)
        {
            TaxTable taxTable = taxTables.Find(taxTable => taxTable.Type.Equals("default", StringComparison.InvariantCultureIgnoreCase));
            if (taxTable == null) return 0;
            return taxTable.Value;
        }
    }
}