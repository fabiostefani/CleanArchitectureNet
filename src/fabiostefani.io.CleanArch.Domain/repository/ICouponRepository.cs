using System.Threading.Tasks;

namespace fabiostefani.io.CleanArch.Domain.Interfaces
{
    public interface ICouponRepository
    {
        Task<Coupon?> GetByCode(string code);
    }
}