namespace fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf
{
    public class OrderItemEf
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}