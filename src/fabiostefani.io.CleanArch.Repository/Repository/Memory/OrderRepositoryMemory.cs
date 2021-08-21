using System.Collections.Generic;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain;
using fabiostefani.io.CleanArch.Domain.Interfaces;

namespace fabiostefani.io.CleanArch.Repository
{
    public class OrderRepositoryMemory : IOrderRepository
    {
        private readonly List<Order> Orders;
        public OrderRepositoryMemory()
        {
            Orders = new List<Order>();
        }


        public void Save(Order order)
        {
            Orders.Add(order);
        }
        public int Count()
        {
            return Orders.Count;
        }
    }
}