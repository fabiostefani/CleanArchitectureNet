namespace fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf
{
    public class StockEntryEf
    {
        public int Id { get; set; }
        public int IdItem { get; set; }
        public string Operation { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}