using fabiostefani.io.CleanArch.Domain.Factory;
using fabiostefani.io.CleanArch.Domain.Interfaces;
using fabiostefani.io.CleanArch.Repository.database.ef;
using fabiostefani.io.CleanArch.Repository.Repository.Database;

namespace fabiostefani.io.CleanArch.Repository.Factory
{
    public class DatabaseRepositoryFactory : IRepositoryFactory
    {
        public ICouponRepository CreateCouponRepository()
        {
            return new CouponRepositoryDatabase(new EfDataBase());
        }

        public IItemRepository CreateItemRepository()
        {
            return new ItemRepositoryDatabase(new EfDataBase());
        }

        public IOrderRepository CreateOrderRepository()
        {
            return new OrderRepositoryDatabase(new EfDataBase());
        }
    }
}