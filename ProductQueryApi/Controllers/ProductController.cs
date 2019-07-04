using Microsoft.AspNetCore.Mvc;
using ProductQueryApi.Cache;
using ProductQueryModels;
using ProductRepository.Interfaces;
using ProductRepository.Models;
using System.Collections.Generic;

namespace ProductRepository.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private IProductCache productCache;

        public ProductController( 
            IProductRepository productRepository,IProductCache productCache)
        {
            this.productRepository = productRepository;
            this.productCache = productCache;
        }

        //[HttpGet]
        //public ICollection<ProductReadModel> All()
        //{
        //    return this.productRepository.GetAll();
        //}

        [HttpGet]
        public IEnumerable<Product> All()
        {
            var products=this.productCache.GetProducts();
            if(products.Count != 0)
            {
                return products;
            }
            return this.productRepository.GetAllProducts();
            
        }

        [HttpGet]
        [Route("GetSpecificProduct")]
        public Product GetSpecificProduct([FromQuery] int id)
        {
            var product = this.productCache.Get(id);
            if(product != null)
            {
                return product;
            }
            return this.productRepository.GetProductById(id);
        }

        [HttpPost]
        public void Add([FromBody] Product product)
        {
            //var product1 = new Product
            //{
            //    ProductName = "book 1",
            //    ProductId = counter,
            //    Description = "book 1 Description",
            //    Price = 100,
            //    CatagoryId = 1,
            //    Catagory = new Catagory
            //    {
            //        CatagoryId = 1,
            //        CatagorCode = "categorycode",
            //        CatagoryDesc = "categoryDescription",
            //        CatagoryName = "categoryName"
            //    }
            //};

            this.productRepository.AddProduct(product);
            //counter++;
        }

        [HttpGet]
        [Route("GetProductsOnSearchedCriteria")]
        public IEnumerable<Product> GetMatchingProducts([FromQuery] string searchedText)
        {
            return this.productRepository.GetSearchedProducts(searchedText);
        }
    }
}
