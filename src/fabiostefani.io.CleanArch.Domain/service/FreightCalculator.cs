namespace fabiostefani.io.CleanArch.Domain
{
    public static class FreightCalculator
    {
        public static decimal Calculate(int distance, Item item)
        {
            decimal price = distance * item.GetVolume() * (item.GetDensity()/100);
            return price < 10 ? 10 : price;
        }
    }
}