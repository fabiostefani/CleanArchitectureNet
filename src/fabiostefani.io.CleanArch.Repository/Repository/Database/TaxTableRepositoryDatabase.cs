using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain.entities;
using fabiostefani.io.CleanArch.Domain.repository;
using fabiostefani.io.CleanArch.Repository.database;
using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;

namespace fabiostefani.io.CleanArch.Repository.Repository.Database
{
    public class TaxTableRepositoryDatabase : ITaxTableRepository
    {
        private readonly IDatabase database;
        public TaxTableRepositoryDatabase(IDatabase database)
        {
            this.database = database;

        }
        public async Task<List<TaxTable>> GetByIdItem(int idItem)
        {
            var taxTableDb = await database.All<TaxTableEf>();
            List<TaxTable> taxTables = new List<TaxTable>();
            foreach (var taxTable in taxTableDb.Where(x=>x.CodigoItem == idItem))
            {
                taxTables.Add(new TaxTable(taxTable.CodigoItem, taxTable.Type, taxTable.Value));
            }
            return taxTables;
        }
    }
}