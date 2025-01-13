using CoreBusiness;

namespace UseCases.ProductsUseCase
{
    public interface IViewProductsByCategoryUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}