using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain.entities;
using fabiostefani.io.CleanArch.Domain.repository;
using fabiostefani.io.CleanArch.Repository.database;
using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;

namespace fabiostefani.io.CleanArch.Repository.Repository.Database
{
    public class StockEntryRepositoryDatabase : IStockEntryRepository
    {
        private readonly IDatabase database;
        public StockEntryRepositoryDatabase(IDatabase database)
        {
            this.database = database;

        }


        public async Task<List<StockEntry>> GetByIdItem(int idItem)
        {
            var stockEntriesDb = await database.All<StockEntryEf>();
            List<StockEntry> stockEntries = new List<StockEntry>();
            foreach (var stockEntryDb in stockEntriesDb.Where(x=>x.IdItem == idItem))
            {
                stockEntries.Add(new StockEntry(stockEntryDb.IdItem, stockEntryDb.Operation, stockEntryDb.Quantity, stockEntryDb.Date));
            }
            return stockEntries;
        }

        public async Task Save(StockEntry stockEntry)
        {
            var stockEntryEf = new StockEntryEf()
            {
                IdItem = stockEntry.IdItem,
                Date = stockEntry.Date,
                Operation = stockEntry.Operation,
                Quantity = stockEntry.Quantity
            };
            await this.database.Add<StockEntryEf>(stockEntryEf);            
        }
        public async Task Clean()
        {
            // IList<StockEntryEf> stockEntries = this.database.Many<StockEntryEf>(stockEntry => stockEntry.Operation == "in").ToList();
            IList<StockEntryEf> stockEntries = await this.database.All<StockEntryEf>();            
            await this.database.RemoveRange<StockEntryEf>(stockEntries);
        }
    }
}