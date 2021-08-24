using System;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;
using fabiostefani.io.CleanArch.Repository.database;
using fabiostefani.io.CleanArch.Repository.database.Ef.ModelEf;

namespace fabiostefani.io.CleanArch.Repository.Repository.Database
{
    public class ItemRepositoryDatabase : IItemRepository
    {
        private readonly IDatabase Database;
        public ItemRepositoryDatabase(IDatabase database)
        {
            this.Database = database;
        }

        public async Task<Item?> GetById(string id)
        {            
            ItemEf itemEf = await this.Database.One<ItemEf>(x => x.Id == Convert.ToInt32(id));

            return new Item(itemEf.Id.ToString(), itemEf.Description, itemEf.Price, itemEf.Width, itemEf.Height, itemEf.Length, itemEf.Weight);
        }
    }
}