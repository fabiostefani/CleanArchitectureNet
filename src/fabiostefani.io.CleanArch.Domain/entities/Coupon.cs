using System;
namespace fabiostefani.io.CleanArch.Domain
{
    public class Coupon
    {
        public string Code { get; private set; }
        public int Percentage { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public Coupon(string code, int percentage, DateTime expireDate)
        {
            Code = code;
            Percentage = percentage;
            ExpireDate = expireDate;
        }

        public bool IsExpired()
        {
            return ExpireDate.Date < DateTime.Now.Date;
        }
    }
}