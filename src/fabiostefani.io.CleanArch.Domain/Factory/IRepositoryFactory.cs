using fabiostefani.io.CleanArch.Domain.Interfaces;
using fabiostefani.io.CleanArch.Domain.repository;

namespace fabiostefani.io.CleanArch.Domain.Factory
{
    public interface IRepositoryFactory
    {
        IItemRepository CreateItemRepository();
        ICouponRepository CreateCouponRepository();
        IOrderRepository CreateOrderRepository();
        ITaxTableRepository CreateTaxTableRepository();
    }
}