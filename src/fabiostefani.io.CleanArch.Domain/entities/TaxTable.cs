namespace fabiostefani.io.CleanArch.Domain.entities
{
    public class TaxTable
    {
        public int CodigoItem { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public TaxTable(int codigoItem, string type, decimal value)
        {
            CodigoItem = codigoItem;
            Type = type;
            Value = value;
        }
    }
}