using System;
using System.Collections.Generic;

namespace Sample.Core.Products
{
    public class ProductManager : IProductManager
    {
        public List<Product> GetAll()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product One", CreatedAt = DateTime.Now },
                new Product { Id = 2, Name = "Product Two", CreatedAt = DateTime.Now },
                new Product { Id = 3, Name = "Product Three", CreatedAt = DateTime.Now },
                new Product { Id = 4, Name = "Product Four", CreatedAt = DateTime.Now },
                new Product { Id = 5, Name = "Product Five", CreatedAt = DateTime.Now },

            };
        }
    }
}
