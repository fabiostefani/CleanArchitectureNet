using fabiostefani.io.CleanArch.Domain.entities;

namespace fabiostefani.io.CleanArch.Domain.service
{
    public class StockCalculator
    {
        public decimal Calculate(List<StockEntry> stockEntries)
        {
            decimal quantity = 0;
            foreach (var stockEntry in stockEntries)
            {
                if (stockEntry.OperationIn()) 
                    quantity += stockEntry.Quantity;
                if (stockEntry.OperationOut()) 
                    quantity -= stockEntry.Quantity;                
            }
            return quantity;
        }
    }
}