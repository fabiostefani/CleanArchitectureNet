namespace fabiostefani.io.CleanArch.Domain.Interfaces
{
    public interface ICouponRepository
    {
        Coupon? GetByCode(string code);
    }
}