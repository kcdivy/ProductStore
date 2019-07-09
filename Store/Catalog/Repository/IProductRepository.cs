using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Models;

namespace Catalog.Repository
{
    public interface IProductRepository
    {
        ICollection<Product> GetAll();
        string Add(Product product);
    }
}
