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

        IDatabase<Catagory> catagoryDatabase;

        IConfiguration Configuration { get; set; }

        string connectionstring;
        public ProductDatabaseRepository(IProductDatabase database, IConfiguration configuration, IDatabase<Catagory> categoryDatabase)
        {
            this.productDatabase = database;
            this.catagoryDatabase = categoryDatabase;
            this.Configuration = configuration;
            this.connectionstring = Configuration["ConnectionString:DefaultConnection"];
            //productList =  new List<Product>()
            //{
            //    new Product() { Name = "book 1", ProductId = Guid.Parse("ef29fc61-abcc-4ac1-9c8c-e5e17b266868"), Category = "ab"},
            //    new Product() { Name = "book 2", ProductId = Guid.Parse("618808a6-8466-4fd8-80da-e8651ec0c0e4"), Category = "bc"},
            //    new Product() { Name = "book 3", ProductId = Guid.Parse("dc2bd686-7eaf-44a3-9fdd-b3645fef9a02"), Category = "cd"},
            //    new Product() { Name = "book 4", ProductId = Guid.Parse("d91d2019-e642-4b00-8b10-2bf07c383787"), Category = "de"}
            //};
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
