using CoreBusiness;

namespace WebApp.ViewModels
{
    public class TransactionsViewModel
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string CashierName { get; set; } = string.Empty;
        public IEnumerable<Transaction> transactions { get; set; } = new List<Transaction>();
    }
}
