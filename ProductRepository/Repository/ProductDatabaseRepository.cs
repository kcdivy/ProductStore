using Database;
using Microsoft.Extensions.Configuration;
using ProductQueryModels;
using ProductRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductRepository.Repository
{
    public class ProductDatabaseRepository : IProductRepository
    {
        private ICollection<Product> productList = null;

        IProductDatabase productDatabase;

        ICatagoryDatabase catagoryDatabase;

        IConfiguration Configuration { get; set; }

        string connectionstring;
        public ProductDatabaseRepository(IProductDatabase database, IConfiguration configuration, ICatagoryDatabase categoryDatabase)
        {
            this.productDatabase = database;
            this.catagoryDatabase = categoryDatabase;
            this.Configuration = configuration;
            this.connectionstring = Configuration["ConnectionStrings:DefaultConnection"];

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.productDatabase.GetAll(connectionstring);
        }

        public Product GetProductById(int id)
        {
            return this.productDatabase.GetById(id, connectionstring);
        }
        public void AddProduct(Product product)
        {
            this.productDatabase.Insert(product, connectionstring);

            //this.productList.Add(new Product()
            //{
            //    Name = product.Name,
            //    ProductId = product.ProductId,
            //    Category =  product.Category
            //});
        }


        public IEnumerable<Catagory> GetAllCatagories()
        {
            return this.catagoryDatabase.GetAll(connectionstring);
        }

        public Catagory GetCatagoryById(int id)
        {
            return this.catagoryDatabase.GetById(id, connectionstring);
        }

        public Catagory GetCatagoryByName(string name)
        {
            return this.catagoryDatabase.GetByName(name, connectionstring);
        }

        public void AddCatagory(Catagory catagory)
        {
            this.catagoryDatabase.Insert(catagory, connectionstring);

        }
        public IEnumerable<Product> GetSearchedProducts(string searchedCriteria)
        {
            return this.productDatabase.GetMatchingProducts(searchedCriteria, connectionstring);
        }
    }

}
