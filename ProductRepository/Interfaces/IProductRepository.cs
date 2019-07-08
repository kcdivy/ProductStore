using System.Collections.Generic;
using ProductQueryModels;
using ProductRepository.Models;

namespace ProductRepository.Interfaces
{
    public interface IProductRepository
    {
        //ICollection<ProductReadModel> GetAll();

        //void Add(ProductReadModel product);
        IEnumerable<Product> GetAllProducts();

        void AddProduct(Product product);

        Product GetProductById(int id);

        IEnumerable<Catagory> GetAllCatagories();

        void AddCatagory(Catagory catagory);

        Catagory GetCatagoryById(int id);

        IEnumerable<Product> GetSearchedProducts(string searchedCriteria);

        Catagory GetCatagoryByName(string name);

    }
}
