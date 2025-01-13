using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;

namespace UseCases.TransactionsUseCase
{
    public class SearchTransactionUseCase : ISearchTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public SearchTransactionUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string cahierName, DateTime startTime, DateTime endTime)
        {
            return transactionRepository.Search(cahierName, startTime, endTime);
        }
    }
}
