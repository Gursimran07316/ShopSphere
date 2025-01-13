using Microsoft.AspNetCore.Mvc;
using UseCases.TransactionsUseCase;
namespace WEBAPP.ViewComponents
   
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        private readonly IViewTransactionByCashierAndDate viewTransactionByCashierAndDate;

        public TransactionsViewComponent(IViewTransactionByCashierAndDate viewTransactionByCashierAndDate)
        {
            this.viewTransactionByCashierAndDate = viewTransactionByCashierAndDate;
        }
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = viewTransactionByCashierAndDate.Execute(userName, DateTime.Now);
            return View(transactions);
        }
    }
}
