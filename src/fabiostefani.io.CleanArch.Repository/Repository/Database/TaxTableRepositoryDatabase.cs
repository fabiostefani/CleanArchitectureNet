using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain.entities;
using fabiostefani.io.CleanArch.Domain.repository;
using fabiostefani.io.CleanArch.Repository.database;

namespace fabiostefani.io.CleanArch.Repository.Repository.Database
{
    public class TaxTableRepositoryDatabase : ITaxTableRepository
    {
        private readonly IDatabase database;
        public TaxTableRepositoryDatabase(IDatabase database)
        {
            this.database = database;

        }
        public async Task<TaxTable?> GetByIdItem(int idItem)
        {
            //var taxTableDb = database.One
        }
    }
}