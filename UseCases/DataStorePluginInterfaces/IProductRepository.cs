using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(int productId, Product product);
        Product ?GetProductById(int productId,bool loadCategory);
        IEnumerable<Product> GetProducts(bool loadCategory);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
    }
}