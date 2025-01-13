using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.TransactionsUseCase
{
    public class AddTransactionUseCase : IAddTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public AddTransactionUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public void Execute(string cahierName, int productId, int soldQty)
        {
            transactionRepository.Add(cahierName, productId, soldQty);
        }
    }
}
