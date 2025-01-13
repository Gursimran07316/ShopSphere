using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using CoreBusiness;
namespace UseCases.TransactionsUseCase
{
    public class ViewTransactionByCashierAndDate : IViewTransactionByCashierAndDate
    {
        private readonly ITransactionRepository transactionRepository;

        public ViewTransactionByCashierAndDate(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string cahierName, DateTime date)
        {
            return transactionRepository.GetByDayAndCashier(cahierName, date);
        }
    }
}
