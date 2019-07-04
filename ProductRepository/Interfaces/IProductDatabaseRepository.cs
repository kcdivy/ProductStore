using ProductQueryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductRepository.Interfaces
{
    public interface IProductDatabaseRepository
    {
        IEnumerable<Product> GetAllProducts();

        void AddProduct(Product product);

        Product GetProductById(int id);

        IEnumerable<Catagory> GetAllCatagories();

        void AddCatagory(Catagory catagory);

        Catagory GetCatagoryById(int id);

        IEnumerable<Product> GetSearchedProducts(string searchedCriteria);
    }
}
