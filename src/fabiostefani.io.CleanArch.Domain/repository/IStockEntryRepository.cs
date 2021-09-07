using fabiostefani.io.CleanArch.Domain.entities;

namespace fabiostefani.io.CleanArch.Domain.repository
{
    public interface IStockEntryRepository
    {
         Task<List<StockEntry>> GetByIdItem(int idItem);
        Task Clean();
        Task Save(StockEntry stockEntry);
    }
}