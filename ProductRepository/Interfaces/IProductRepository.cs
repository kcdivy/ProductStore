using System.Collections.Generic;
using ProductRepository.Models;

namespace ProductRepository.Interfaces
{
    public interface IProductRepository
    {
        ICollection<ProductReadModel> GetAll();

        void Add(ProductReadModel product);

    }
}
