using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationUnitTesting.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string title { get; set; }
        public int price { get; set; }
    }

    public class ProductStore
    {
        public List<Product> Products { get; set; }

        public ProductStore()
        {
            Products = new List<Product>()
            {
                new Product() { productId = 101, title = "Pen", price = 20 },
                new Product() { productId = 102, title = "Copy", price = 50 },
                new Product() { productId = 103, title = "Pencil", price = 10 }
            };
        }
    }
}
