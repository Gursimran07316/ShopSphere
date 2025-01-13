using Microsoft.AspNetCore.Mvc;
using UseCases.CategoriesUseCases;
using UseCases.ProductsUseCase;
using WebApp.ViewModels;



namespace WEBAPP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IViewProductsUseCase productsUseCase;
        private readonly IAddProductUseCase addProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IDeleteProductUseCase deleteProductUseCase;
        private readonly IViewCategoryUseCase viewCategoryUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IViewProductsByCategoryUseCase viewProductsByCategoryUseCase;

        public ProductsController(IViewProductsUseCase productsUseCase,IAddProductUseCase addProductUseCase,IEditProductUseCase editProductUseCase,
            IDeleteProductUseCase deleteProductUseCase,IViewCategoryUseCase viewCategoryUseCase,IViewSelectedProductUseCase viewSelectedProductUseCase, IViewProductsByCategoryUseCase viewProductsByCategoryUseCase)
        {
            this.productsUseCase = productsUseCase;
            this.addProductUseCase = addProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.viewCategoryUseCase = viewCategoryUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.viewProductsByCategoryUseCase = viewProductsByCategoryUseCase;
        }
        public IActionResult Index()
        {
            var products = productsUseCase.Execute(true);
            return View(products);
        }
        public IActionResult add()
        {
            ViewBag.Action = "add";
            var productViewModel = new ProductViewModel {
                Categories = viewCategoryUseCase.Execute()
            };
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
             addProductUseCase.Execute(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Categories = viewCategoryUseCase.Execute();

            return View(productViewModel);

        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";

            var productViewModel = new ProductViewModel
            {
                Categories = viewCategoryUseCase.Execute(),
                Product= viewSelectedProductUseCase.Execute(id.HasValue ? id.Value : 0,true)
            };
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                editProductUseCase.Execute(productViewModel.Product.ProductId,productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Categories = viewCategoryUseCase.Execute();

            return View(productViewModel);

        }
        public IActionResult Delete(int id)
        {
           deleteProductUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products=viewProductsByCategoryUseCase.Execute(categoryId);
            return PartialView("_products", products);
        }
    }
}
