using CoreBusiness;

namespace UseCases.TransactionsUseCase
{
    public interface IViewTransactionByCashierAndDate
    {
        IEnumerable<Transaction> Execute(string cahierName, DateTime date);
    }
}