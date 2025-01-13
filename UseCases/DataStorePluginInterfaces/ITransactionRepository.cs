
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        void Add(string cahierName, int productId,  int soldQty);
        IEnumerable<Transaction> GetByDayAndCashier(string cahierName, DateTime date);
        IEnumerable<Transaction> Search(string cahierName, DateTime startTime, DateTime endTime);
    }
}