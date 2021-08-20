using System.Threading.Tasks;

namespace fabiostefani.io.CleanArch.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<Item?> GetById(string id);
    }
}