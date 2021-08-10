namespace fabiostefani.io.CleanArch.Domain
{
    public class Coupon
    {
        public string Code { get; private set; }
        public int Percentage { get; private set; }
        public Coupon(string code, int percentage)
        {
            Code = code;
            Percentage = percentage;
        }
    }
}