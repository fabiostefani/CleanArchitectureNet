namespace fabiostefani.io.CleanArch.Domain
{
    public class Item
    {
        public string Id { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal Width { get; private set; }
        public decimal Height { get; private set; }
        public decimal Length { get; private set; }
        public decimal Weight { get; private set; }
        public Item(string id, string description, decimal price, decimal width, decimal height, decimal length, decimal weight )
        {
            Id = id;
            Description = description;
            Price = price;
            Width = width;
            Height = height;
            Length = length;
            Weight = weight;
        }    

        public decimal GetVolume()
        {
            return Width / 100 * Height / 100 * Length / 100;            
        }

        public decimal GetDensity()
        {
            return Weight / GetVolume();
        }
    }
}