namespace fabiostefani.io.CleanArch.Repository.database.ef.ModelEf
{
    public class ItemEf
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }
    }
}