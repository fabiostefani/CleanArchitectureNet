using fabiostefani.io.CleanArch.Domain.entities;
using fabiostefani.io.CleanArch.Domain.repository;

namespace fabiostefani.io.CleanArch.Repository.Repository.Memory
{
    public class StockEntryRepositoryMemory : IStockEntryRepository
    {
        private readonly IList<StockEntry> _stockEntries;
        public StockEntryRepositoryMemory()
        {
            _stockEntries = new List<StockEntry>{
                new StockEntry(1, "in" , 10, DateTime.Now),
                new StockEntry(2, "in" , 10, DateTime.Now),
                new StockEntry(3, "in" , 10, DateTime.Now),
            };
        }


        public Task<List<StockEntry>> GetByIdItem(int idItem)
        {
            return Task.FromResult(_stockEntries.Where(x => x.IdItem == idItem).ToList());
        }

        public Task Save(StockEntry stockEntry)
        {
            _stockEntries.Add(stockEntry);
            return Task.FromResult(true);
        }
        public Task Clean()
        {
            _stockEntries.Where(stockEntry => stockEntry.Operation == "in").ToList().Clear();
            return Task.FromResult(true);
        }
    }
}