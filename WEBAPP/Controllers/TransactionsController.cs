using Microsoft.AspNetCore.Mvc;
using UseCases.interfaces;

using WebApp.ViewModels;

namespace WEBAPP.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ISearchTransactionUseCase searchTransactionUseCase;

        public TransactionsController(ISearchTransactionUseCase searchTransactionUseCase)
        {
            this.searchTransactionUseCase = searchTransactionUseCase;
        }
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel= new TransactionsViewModel();
            return View(transactionsViewModel);
        }
        [HttpPost]
        public IActionResult getTransactions(TransactionsViewModel transactionsViewModel)
        {
            if (ModelState.IsValid )
            {
                if (transactionsViewModel != null) {
                    transactionsViewModel.transactions = searchTransactionUseCase.Execute(transactionsViewModel.CashierName,
                        transactionsViewModel.StartDate, transactionsViewModel.EndDate);
                        }
            }
            return View("Index",transactionsViewModel);
        }
    }
}
