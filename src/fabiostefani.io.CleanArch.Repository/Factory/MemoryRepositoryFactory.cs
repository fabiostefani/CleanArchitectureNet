using fabiostefani.io.CleanArch.Domain.Factory;
using fabiostefani.io.CleanArch.Domain.Interfaces;

namespace fabiostefani.io.CleanArch.Repository.Factory
{
    public class MemoryRepositoryFactory : IRepositoryFactory
    {
        public ICouponRepository CreateCouponRepository()
        {
            return new CouponRepositoryMemory();
        }

        public IItemRepository CreateItemRepository()
        {
            return new ItemRepositoryMemory();
        }

        public IOrderRepository CreateOrderRepository()
        {
            return OrderRepositoryMemory.GetInstance();
        }
    }
}