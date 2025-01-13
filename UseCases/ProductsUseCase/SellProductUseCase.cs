using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.TransactionsUseCase;

namespace UseCases.ProductsUseCase
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IAddTransactionUseCase addTransactionUseCase;

        public SellProductUseCase(IProductRepository productRepository, IAddTransactionUseCase addTransactionUseCase)
        {
            this.productRepository = productRepository;
            this.addTransactionUseCase = addTransactionUseCase;
        }
        public void Execute(string cashierName, int productId, int qtyToSell)
        {
            var product = productRepository.GetProductById(productId, true);
            if (product == null) return;
            addTransactionUseCase.Execute(cashierName, productId, qtyToSell);
            product.Quantity -= qtyToSell;
            productRepository.UpdateProduct(productId, product);
        }
    }
}
