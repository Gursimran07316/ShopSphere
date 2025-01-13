using System.ComponentModel.DataAnnotations;
using UseCases.ProductsUseCase;
using WebApp.ViewModels;

namespace WEBAPP.ViewModels.Validations
{
    public class SalesViewModel_EnsureProperQuantity :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;
            if(salesViewModel!= null)
            {
                if (salesViewModel.QuantoityToSell <= 0)
                {
                    return new ValidationResult("The quantity to sell has to be greater than 0");
                }
                else
                {
                    var getProductByIdUseCase = validationContext.GetServices(typeof(IViewSelectedProductUseCase)) as IViewSelectedProductUseCase;
                    if (getProductByIdUseCase != null)
                    {
                        var product=getProductByIdUseCase.Execute(salesViewModel.SelectedPoductId,true);
                        if (product != null)
                        {
                            if (salesViewModel.QuantoityToSell > product.Quantity)
                            {
                                return new ValidationResult($"{product.Name}  has only {product.Quantity} left");
                            }
                        }
                        else
                        {
                            return new ValidationResult("Product doesnot exist");
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
