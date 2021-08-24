using System.Threading.Tasks;

namespace fabiostefani.io.CleanArch.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> Save(Order order);
        Task<int> Count();
        Task Clean();
        Task<Order?> GetByCode(string code);
    }
}