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


        [HttpGet]
        public IEnumerable<Product> All()
        {
        //    var products=this.productCache.GetProducts();
        //    if(products.Count != 0)
        //    {
        //        return products;
        //    }
            return this.productRepository.GetAllProducts();
            
            
        }

        [HttpGet]
        [Route("GetById")]
        public Product GetSpecificProduct([FromQuery] int id)
        {
            var product = this.productCache.Get(id);
            if(product != null)
            {
                return product;
            }
            product = this.productRepository.GetProductById(id);
            this.productCache.Put(product);
            return product;
        }

        [HttpGet]
        [Route("GetProductsOnSearchedCriteria")]
        public IEnumerable<Product> GetMatchingProducts([FromQuery] string searchedText)
        {
            return this.productRepository.GetSearchedProducts(searchedText);
        }
    }
}
