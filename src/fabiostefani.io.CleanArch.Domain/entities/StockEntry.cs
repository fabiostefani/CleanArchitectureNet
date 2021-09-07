namespace fabiostefani.io.CleanArch.Domain.entities
{
    public class StockEntry
    {
        public StockEntry(int idItem, string operation, decimal quantity, DateTime date)
        {
            IdItem = idItem;
            Operation = operation;
            Quantity = quantity;
            Date = date;
        }

        public int IdItem { get; private set; }
        public string Operation { get; private set; }
        public decimal Quantity { get; private set; }
        public DateTime Date { get; private set; }

        public bool OperationIn()
        {
            return Operation.Equals("in", StringComparison.InvariantCultureIgnoreCase);
        }

        public bool OperationOut()
        {
            return Operation.Equals("out", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}