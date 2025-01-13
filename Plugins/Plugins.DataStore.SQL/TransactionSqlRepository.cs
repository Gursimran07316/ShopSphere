using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Plugins.DataStore.SQL
{
    public class TransactionSqlRepository:ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionSqlRepository(MarketContext db)
        {
            this.db = db;
        }

        public void Add(string cahierName, int productId, int soldQty)
        {
            var prd= db.Products.FirstOrDefault(x => x.ProductId == productId);
            if (prd == null) return;
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = prd.Name == null ? "" : prd.Name,
                TimeStamp = DateTime.Now,
                Price = prd.Price.HasValue ? prd.Price.Value : 0,
                BeforeQty = prd.Quantity.HasValue ? prd.Quantity.Value : 0,
                SoldQty = soldQty,
                CashierName = cahierName
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> GetByDayAndCashier(string cahierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cahierName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date == date.Date).ToList();
            }
            else
            {
                return db.Transactions.Where(x =>
                x.TimeStamp.Date == date.Date &&
                EF.Functions.Like(x.CashierName,$"%{cahierName}%")).ToList();
            }
        }

        public IEnumerable<Transaction> Search(string cahierName, DateTime startTime, DateTime endTime)
        {
            if (string.IsNullOrWhiteSpace(cahierName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date >= startTime.Date && x.TimeStamp<= endTime.Date.AddDays(1)).ToList();
            }
            else
            {
                return db.Transactions.Where(x =>
                x.TimeStamp.Date >= startTime.Date && x.TimeStamp <= endTime.Date.AddDays(1) &&
                EF.Functions.Like(x.CashierName, $"%{cahierName}%")).ToList();
            }
        }
    }
}
