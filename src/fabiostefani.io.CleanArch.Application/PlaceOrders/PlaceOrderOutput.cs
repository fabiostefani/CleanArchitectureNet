namespace fabiostefani.io.CleanArch.Application.Dtos
{
    public class PlaceOrderOutput
    {
        public decimal Total { get; set; }
        public decimal Freight { get; set; }
        public string Code { get; set; }
        public decimal Taxes { get; set; }
    }
}