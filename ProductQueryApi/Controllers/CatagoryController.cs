using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductQueryModels;
using ProductRepository.Interfaces;

namespace ProductQueryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private IProductRepository productRepository;

        public CatagoryController(
            IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [HttpGet]
        public IEnumerable<Catagory> All()
        {
            return this.productRepository.GetAllCatagories();
        }

        [HttpGet]
        [Route("GetCatagoryByName")]
        public Catagory GetCatagoryByName(string name)
        {
            return this.productRepository.GetCatagoryByName(name);
        }
    }
}