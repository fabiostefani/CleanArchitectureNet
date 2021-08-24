using System.Collections.Generic;
using System.Linq;
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


        public Task<bool> Save(Order order)
        {
            Orders.Add(order);
            return Task.FromResult(true);
        }
        public Task<int> Count()
        {
            return Task.FromResult(Orders.Count);
        }

        public Task Clean()
        {
            Orders.Clear();
            return Task.FromResult(true);
        }

        public Task<Order?> GetByCode(string code)
        {
            return Task.FromResult(Orders.FirstOrDefault(x => x.Code.Value == code));
        }
    }
}