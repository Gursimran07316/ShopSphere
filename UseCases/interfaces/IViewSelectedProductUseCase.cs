using CoreBusiness;

namespace UseCases.ProductsUseCase
{
    public interface IViewSelectedProductUseCase
    {
        Product Execute(int productId, bool loadCategory);
    }
}