using Microsoft.AspNetCore.Mvc;
using UseCases.CategoriesUseCases;

using WebApp.ViewModels;
using UseCases.ProductsUseCase;

namespace WEBAPP.Controllers
{
    public class SalesController : Controller
    {
        private readonly IViewCategoryUseCase viewCategoryUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUse;
        private readonly ISellProductUseCase sellProductUseCase;

        public SalesController(IViewCategoryUseCase viewCategoryUseCase,IViewSelectedProductUseCase viewSelectedProductUse,ISellProductUseCase sellProductUseCase
            )
        {
            this.viewCategoryUseCase = viewCategoryUseCase;
            this.viewSelectedProductUse = viewSelectedProductUse;
            this.sellProductUseCase = sellProductUseCase;
        }
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = viewCategoryUseCase.Execute()
            };
            return View(salesViewModel);
        }
        public IActionResult SelectedProductPartial(int productId)
        {
            var product = viewSelectedProductUse.Execute(productId,true);
            return PartialView("_SellProducts",product);
        }
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {


                sellProductUseCase.Execute(
                    "Cashier1",
                    salesViewModel.SelectedPoductId,
                     salesViewModel.QuantoityToSell
                    );


            }
            var product = viewSelectedProductUse.Execute(salesViewModel.SelectedPoductId, true);
            salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
            salesViewModel.Categories = viewCategoryUseCase.Execute();

            return View("Index", salesViewModel);
        }
    }
}
