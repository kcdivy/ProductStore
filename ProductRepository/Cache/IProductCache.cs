using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductQueryModels;

namespace ProductQueryApi.Cache
{
    public interface IProductCache
    {
        IList<Product> GetProducts();
        
        void Put(Product product);

        Product Get(int productId);
    }
}
