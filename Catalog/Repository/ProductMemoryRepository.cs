using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Repository
{
    public class ProductMemoryRepository : IProductRepository
    {
        private ICollection<Product> productList = null;

        public ProductMemoryRepository()
        {
            productList =  new List<Product>()
            {
                //new Product() { Name = "book 1", ProductId = Guid.Parse("ef29fc61-abcc-4ac1-9c8c-e5e17b266868"), Category = "ab"},
                //new Product() { Name = "book 2", ProductId = Guid.Parse("618808a6-8466-4fd8-80da-e8651ec0c0e4"), Category = "bc"},
                //new Product() { Name = "book 3", ProductId = Guid.Parse("dc2bd686-7eaf-44a3-9fdd-b3645fef9a02"), Category = "cd"},
                //new Product() { Name = "book 4", ProductId = Guid.Parse("d91d2019-e642-4b00-8b10-2bf07c383787"), Category = "de"}
            };
        }

        public ICollection<Product> GetAll()
        {
            return this.productList;
        }

        public string Add(Product product)
        {
            var id = Guid.NewGuid();
            this.productList.Add(new Product()
            {
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                CatagoryName = product.CatagoryName
            });

            return id.ToString();
        }
    }
}
