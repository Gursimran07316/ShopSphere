using CoreBusiness;

namespace UseCases.ProductsUseCase
{
    public interface IAddProductUseCase
    {
        void Execute(Product product);
    }
}