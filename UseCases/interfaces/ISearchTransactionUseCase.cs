using CoreBusiness;

namespace UseCases.interfaces
{
    public interface ISearchTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string cahierName, DateTime startTime, DateTime endTime);
    }
}