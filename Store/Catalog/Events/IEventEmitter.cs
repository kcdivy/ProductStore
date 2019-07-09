using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Events
{
    public interface IEventEmitter
    {
        void EmitProductAddedEvent(NewProductEvent newProductEvent);
    }
}
