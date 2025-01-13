using System.ComponentModel.DataAnnotations;
using CoreBusiness;
using WEBAPP.ViewModels.Validations;

namespace WebApp.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int SelectedPoductId { get; set; }
        [Display(Name = "Quantity")]
        [Range(1,int.MaxValue)]
        [SalesViewModel_EnsureProperQuantity]
        public int QuantoityToSell { get; set; }
    }
}
