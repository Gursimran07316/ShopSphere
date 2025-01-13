using CoreBusiness;

namespace UseCases.ProductsUseCase
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute(bool loadCategory);
    }
}