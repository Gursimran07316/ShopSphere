namespace WebApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Price { get; set; }
        public int BeforeQty { get; set; }  
        public int SoldQty { get; set; }
        public string CashierName { get; set; } = string.Empty;

    }
}
