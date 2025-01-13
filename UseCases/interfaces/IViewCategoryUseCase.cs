using CoreBusiness;

namespace UseCases.CategoriesUseCases
{
    public interface IViewCategoryUseCase
    {
        IEnumerable<Category> Execute();
    }
}