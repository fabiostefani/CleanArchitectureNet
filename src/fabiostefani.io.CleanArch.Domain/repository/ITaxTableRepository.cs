using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Domain.entities;

namespace fabiostefani.io.CleanArch.Domain.repository
{
    public interface ITaxTableRepository
    {
         Task<List<TaxTable>> GetByIdItem(int idItem);
    }
}