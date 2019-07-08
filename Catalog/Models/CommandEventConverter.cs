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
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                CatagoryName = product.CatagoryName,
                CatagoryId = product.CatagoryId
            };

            return newproductEvent;
        }
    }
}
