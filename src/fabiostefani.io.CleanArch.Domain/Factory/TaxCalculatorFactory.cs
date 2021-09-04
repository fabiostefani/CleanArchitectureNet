using fabiostefani.io.CleanArch.Domain.service;

namespace fabiostefani.io.CleanArch.Domain.Factory
{
    public static class TaxCalculatorFactory
    {
        const int November = 11;
        public static TaxCalculator Create(DateTime date)
        {
            if (date.Month == November)
            {
                return new NovemberTaxCalculator();
            }
            return new DefaultTaxCalculator();
        }
    }
}