using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using UseCases.CategoriesUseCases;


namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IViewCategoryUseCase viewCategoryUseCase;
        private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;
        private readonly IAddCategoryUseCase addCategoryUseCase;
        private readonly IEditCategoryUseCase editCategoryUseCase;
        private readonly IDeleteCategoryUseCase deleteCategoryUseCase;

        public CategoriesController(IViewCategoryUseCase viewCategoryUseCase,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase,IAddCategoryUseCase addCategoryUseCase,IEditCategoryUseCase editCategoryUseCase,IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            this.viewCategoryUseCase = viewCategoryUseCase;
            this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
            this.addCategoryUseCase = addCategoryUseCase;
            this.editCategoryUseCase = editCategoryUseCase;
            this.deleteCategoryUseCase = deleteCategoryUseCase;
        }
        public IActionResult Index()
        {
            var categories =viewCategoryUseCase.Execute();
            return View(categories);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";

            var category = viewSelectedCategoryUseCase.Execute(id.HasValue ? id.Value : 0);
        
           return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                editCategoryUseCase.Execute(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
       
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid && category !=null)
            {
                addCategoryUseCase.Execute(category);
            return RedirectToAction(nameof(Index));
            }
            return View(category);

        }
          public IActionResult Delete(int id)
        {
            deleteCategoryUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
