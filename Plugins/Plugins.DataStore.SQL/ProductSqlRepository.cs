using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductSqlRepository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductSqlRepository(MarketContext db)
        {
            this.db = db;
        }
        public void AddProduct(Product product)
        {
           db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null) return;
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product? GetProductById(int productId, bool loadCategory)
        {
            if (loadCategory) { 
            return db.Products
                    .Include(x=>x.Category)
                    .FirstOrDefault(x=>x.ProductId == productId);
                    }
            else return db.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public IEnumerable<Product> GetProducts(bool loadCategory)
        {
            if (loadCategory)
            {
                return db.Products.Include(x => x.Category).OrderBy(x => x.Category).ToList();
            }
            else
           return db.Products.OrderBy(x=>x.Category).ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId)return;
            var prd = db.Products.Find(productId);
            if (prd == null) return;
            prd.CategoryId=product.CategoryId;
            prd.Name=product.Name;
            prd.Price = product.Price;
            prd.Quantity = product.Quantity;

        db.SaveChanges();
        }
    }
}
