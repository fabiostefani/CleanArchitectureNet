namespace fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf
{
    public class TaxTableEf 
    {
        public int Id { get; set; }
        public int CodigoItem { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
    }
}