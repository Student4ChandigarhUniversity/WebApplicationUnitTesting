using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationUnitTesting.Models
{
    public interface IProductStore
    {
        bool FindProduct(int id);
        Product FindProduct(string title , int price);
        List<Product> GetAllProducts();
    }

    public class ProductService : IProductStore
    {
        ProductStore store;
        public ProductService()
        {
            store = new ProductStore();
        }

        public bool FindProduct(int id)
        {
            Product product = store.Products.SingleOrDefault(c => c.productId == id);

            if(product == null)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }

        public Product FindProduct(string title, int price)
        {
            Product product = store.Products.SingleOrDefault(c => c.title == title && c.price == price);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return store.Products;
        }
    }
}
