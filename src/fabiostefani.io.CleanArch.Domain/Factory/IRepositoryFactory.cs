using fabiostefani.io.CleanArch.Domain.Interfaces;

namespace fabiostefani.io.CleanArch.Domain.Factory
{
    public interface IRepositoryFactory
    {
        IItemRepository CreateItemRepository();
        ICouponRepository CreateCouponRepository();
        IOrderRepository CreateOrderRepository();
    }
}