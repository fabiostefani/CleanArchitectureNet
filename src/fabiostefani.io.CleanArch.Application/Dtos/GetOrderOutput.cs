using System.Collections.Generic;

namespace fabiostefani.io.CleanArch.Application.Dtos
{
    public class GetOrderOutput
    {
        public decimal Total { get; set; }
        public decimal Freight { get; set; }
        public string Code { get; set; }
        public IList<GetOrderItemsOutput> OrderItems { get; set; }
    }

    public class GetOrderItemsOutput
    {
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }        
    }
}