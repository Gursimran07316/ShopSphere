using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore.InMemory
{
   public class TransactionInMemoryRepostiory : ITransactionRepository
    {
        public List<Transaction> transactions = new List<Transaction>();
        private readonly IProductRepository productRepository;

        public TransactionInMemoryRepostiory(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public  IEnumerable<Transaction> GetByDayAndCashier(string cahierName, DateTime date)
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
        public  IEnumerable<Transaction> Search(string cahierName, DateTime startTime, DateTime endTime)
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
        public  void Add(string cahierName, int productId, int soldQty)
        {
           var prd =productRepository.GetProductById(productId,true);
       
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = prd.Name == null ? "": prd.Name,
                TimeStamp = DateTime.Now,
                Price = prd.Price.HasValue ? prd.Price.Value : 0,
                BeforeQty = prd.Quantity.HasValue ? prd.Quantity.Value : 0,
                SoldQty = soldQty,
                CashierName = cahierName


            };
            if (transactions != null && transactions.Count > 0)
            {
                var maxId = transactions.Max(x => x.TransactionId);
                transaction.TransactionId = maxId + 1;
            }
            else
            {
                transaction.TransactionId = 1;
            }
            transactions?.Add(transaction);
        }
    }
}
