using System.Collections.Generic;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;

namespace fabiostefani.io.CleanArch.Repository
{
    public class ItemRepositoryMemory : IItemRepository
    {
        private readonly List<Item> Items;
        public ItemRepositoryMemory()
        {
            Items = new List<Item>()
            {
                new Item("1", "Guitarra", 1000, 100, 50, 15, 3),
                new Item("2", "Amplificador", 5000, 50, 50, 50, 22),
                new Item("3", "Cabo", 30, 10, 10, 10, 1)
            };
        }
        public Item? GetById(string id)
        {
            return Items.Find(item => item.Id == id);
        }
    }
}