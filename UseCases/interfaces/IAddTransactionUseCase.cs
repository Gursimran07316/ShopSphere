namespace UseCases.TransactionsUseCase
{
    public interface IAddTransactionUseCase
    {
        void Execute(string cahierName, int productId, int soldQty);
    }
}