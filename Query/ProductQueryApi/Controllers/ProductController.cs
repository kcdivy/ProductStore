using Microsoft.AspNetCore.Mvc;
using ProductRepository.Interfaces;
using ProductRepository.Models;
using System.Collections.Generic;

namespace ProductRepository.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController( 
            IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ICollection<ProductReadModel> All()
        {
            return this.productRepository.GetAll();
        }
    }
}
