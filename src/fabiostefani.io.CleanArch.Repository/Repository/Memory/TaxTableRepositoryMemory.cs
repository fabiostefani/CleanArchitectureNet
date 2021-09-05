using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain.entities;
using fabiostefani.io.CleanArch.Domain.repository;

namespace fabiostefani.io.CleanArch.Repository.Repository.Memory
{
    public class TaxTableRepositoryMemory : ITaxTableRepository
    {
        private readonly List<TaxTable> TaxTables;
        public TaxTableRepositoryMemory()
        {
            TaxTables = new List<TaxTable>{
                new TaxTable("1", "default", 15),
                new TaxTable("2", "default", 15),
                new TaxTable("3", "default", 5),
                new TaxTable("1", "november", 5),
                new TaxTable("2", "november", 5),
                new TaxTable("3", "november", 1),
            };
        }
        public Task<TaxTable?> GetByIdItem(int idItem)
        {
            return Task.FromResult(TaxTables.FirstOrDefault(taxTable => taxTable.CodigoItem == idItem));            
        }
    }
}