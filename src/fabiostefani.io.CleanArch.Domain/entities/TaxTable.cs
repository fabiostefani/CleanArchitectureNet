namespace fabiostefani.io.CleanArch.Domain.entities
{
    public class TaxTable
    {
        public string CodigoItem { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public TaxTable(string codigoItem, string type, decimal value)
        {
            CodigoItem = codigoItem;
            Type = type;
            Value = value;
        }
    }
}