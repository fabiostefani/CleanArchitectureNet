namespace fabiostefani.io.CleanArch.Domain
{
    public class OrderItem
    {
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(string description, decimal price, int quantity)
        {
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotal()
        {
            return Price * Quantity;
        }
    }
}