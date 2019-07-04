using ProductQueryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public interface IProductDatabase:IDatabase<Product>
    {
        IEnumerable<Product> GetMatchingProducts(string searchedCriteria, string connectionString);
    }
}
