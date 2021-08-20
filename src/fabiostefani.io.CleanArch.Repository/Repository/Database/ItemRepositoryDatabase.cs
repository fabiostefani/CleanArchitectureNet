using System;
using System.Threading;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;
using fabiostefani.io.CleanArch.Repository.database;
using fabiostefani.io.CleanArch.Repository.database.ef;
using fabiostefani.io.CleanArch.Repository.database.ef.ModelEf;
using Microsoft.EntityFrameworkCore;

namespace fabiostefani.io.CleanArch.Repository.Repository.Database
{
    public class ItemRepositoryDatabase : IItemRepository
    {
        public IDatabase Database { get; }
        public ItemRepositoryDatabase(IDatabase database)
        {
            Database = database;
        }

        public async Task<Item?> GetById(string id)
        {            
            ItemEf itemEf = await Database.One<ItemEf>(x => x.Id == Convert.ToInt32(id));

            return new Item(itemEf.Id.ToString(), itemEf.Description, itemEf.Price, itemEf.Width, itemEf.Height, itemEf.Length, itemEf.Weight);
        }
    }
}