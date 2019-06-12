using System;
using System.Collections.Generic;
using ProductRepository.Interfaces;
using ProductRepository.Models;

namespace ProductRepository.Repository
{
    public class ProductMemoryRepository : IProductRepository
    {
        private ICollection<ProductReadModel> productList = null;

        public ProductMemoryRepository()
        {
            productList =  new List<ProductReadModel>()
            {
                new ProductReadModel() { ProductName = "book 1", ProductId = 1000, CatagoryName = "ab"},
                new ProductReadModel() { ProductName = "book 2", ProductId = 1001, CatagoryName = "bc"},
                new ProductReadModel() { ProductName = "book 3", ProductId = 1003, CatagoryName = "cd"},
                new ProductReadModel() { ProductName = "book 4", ProductId = 1004, CatagoryName = "de"}
            };
        }

        public ICollection<ProductReadModel> GetAll()
        {
            return this.productList;
        }

        public void Add(ProductReadModel product)
        {
            this.productList.Add(product);
        }
    }
}
