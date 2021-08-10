using System.Collections.Generic;

namespace fabiostefani.io.CleanArch.Application.Dtos
{
    public class PlaceOrderInput
    {
        public string Cpf { get; set; }
        public string Coupon { get; set; }
        public List<PlaceOrderItemInput> Items { get; set; }
        public PlaceOrderInput()
        {
            Items = new List<PlaceOrderItemInput>();
            Cpf = string.Empty;
            Coupon = string.Empty;
        }
    }

    public class PlaceOrderItemInput
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public PlaceOrderItemInput()
        {
            Description = string.Empty;
        }
    }
}