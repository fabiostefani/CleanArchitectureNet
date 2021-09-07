namespace fabiostefani.io.CleanArch.Domain.service.PlaceOrders
{
    public class OrderCreatorInput
    {
        public string Cpf { get; set; }
        public string Coupon { get; set; }
        public string ZipCode { get; set; }
        public DateTime IssueDate { get; set; }
        public List<OrderCreatorItemInput> OrderItems { get; set; }
        public OrderCreatorInput()
        {
            OrderItems = new List<OrderCreatorItemInput>();
            Cpf = string.Empty;
            Coupon = string.Empty;
            ZipCode = string.Empty;
        }
    }

    public class OrderCreatorItemInput
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public OrderCreatorItemInput()
        {
            ItemId = string.Empty;
        }
    }
}