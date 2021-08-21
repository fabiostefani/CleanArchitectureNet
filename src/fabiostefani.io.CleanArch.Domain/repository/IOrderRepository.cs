using System.Threading.Tasks;

namespace fabiostefani.io.CleanArch.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
        int Count();
    }
}