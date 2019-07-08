using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using ProductQueryModels;

namespace ProductQueryApi.Cache
{
    public class MemoryProductCache : IProductCache
    {
        private IMemoryCache _cache;

        private IList<Product> _allProducts;

        public MemoryProductCache(IMemoryCache cache)
        {
            _cache = cache;
            _allProducts = new List<Product>();

        }

        public IList<Product> GetProducts()
        {
            return _allProducts;   
        }

        public void Put(Product product)
        {
            _cache.Set(product.ProductId, product,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));
            _allProducts.Add(product);
        }

        public Product Get(int productId)
        {
            return _cache.Get<Product>(productId);
        }
    }
}

