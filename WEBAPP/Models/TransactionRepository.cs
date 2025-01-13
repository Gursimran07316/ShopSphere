using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Models
{
    public static class TransactionRepository
    {
        public static List<Transaction> transactions = new List<Transaction>();

        public static IEnumerable<Transaction> GetByDayAndCashier(string cahierName, DateTime date)
        {

            if (string.IsNullOrEmpty(cahierName))
            {
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            }
            else
            {
                return transactions.Where(x => x.CashierName.ToLower().Contains(cahierName.ToLower()) && x.TimeStamp.Date == date.Date);
            }
        }
        public static IEnumerable<Transaction> Search(string cahierName, DateTime startTime, DateTime endTime)
        {

            {
                if (string.IsNullOrEmpty(cahierName))
                {
                    return transactions.Where(x => x.TimeStamp >= startTime && x.TimeStamp <= endTime.Date.AddDays(1));
                }
                else
                {
                    return transactions.Where(x => x.CashierName.ToLower().Contains(cahierName.ToLower()) && x.TimeStamp >= startTime && x.TimeStamp <= endTime.Date.AddDays(1));
                }

            }
        }
        public static void Add(string cahierName, int productId,string productName,double price,int beforeQty,int soldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cahierName


            };
            if (transactions!= null && transactions.Count > 0) {
                var maxId = transactions.Max(x => x.TransactionId);
                transaction.TransactionId = maxId + 1;
            } else
            {
                transaction.TransactionId = 1;
            }
           transactions?.Add(transaction);
        }
    }
}
