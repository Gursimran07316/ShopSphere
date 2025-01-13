using CoreBusiness;

namespace UseCases.ProductsUseCase
{
    public interface IEditProductUseCase
    {
        void Execute(int productId, Product product);
    }
}