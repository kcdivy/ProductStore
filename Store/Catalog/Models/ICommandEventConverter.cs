using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Events;

namespace Catalog.Models
{
    public interface ICommandEventConverter
    {
        NewProductEvent CommandToEvent(Product product);
    }
}
