using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Events;

namespace Catalog.Models
{
    public class CommandEventConverter : ICommandEventConverter
    {
        public NewProductEvent CommandToEvent(Product product)
        {
            var newproductEvent = new NewProductEvent()
            {
                ProductName = product.Name,
                ProductId = new Random(2000).Next(6000),
                CatagoryName = product.Category
            };

            return newproductEvent;
        }
    }
}
