using EventSubscriber.Interfaces;
using Microsoft.Extensions.Logging;
using ProductRepository.Interfaces;
using ProductRepository.Models;

namespace EventSubscriber.Events
{
    public class NewProductEventProcessor : IEventProcessor
    {
        private ILogger logger;
        private IEventSubscriber subscriber;

        public NewProductEventProcessor(
            ILogger<NewProductEventProcessor> logger,
            IEventSubscriber eventSubscriber,
            IProductRepository productRepository
        )
        {
            this.logger = logger;
            this.subscriber = eventSubscriber;
            this.subscriber.ProductAddedEventReceived += (prd) => {
                if (prd?.Product != null)
                {
                    productRepository.AddProduct(prd.Product);
                }
                else if (prd?.Catagory != null)
                {
                    productRepository.AddCatagory(prd.Catagory);
                }

                //productRepository.Add(new ProductReadModel()
                //{
                //    ProductName = prd.ProductName,
                //    ProductId = prd.ProductId,
                //    Description = prd.Description,
                //    Price = prd.Price,
                //    CatagoryId = prd.CatagoryId,
                //    CatagoryCode = prd.CatagoryCode,
                //    CatagoryDesc = prd.CatagoryDesc,
                //    CatagoryName = prd.CatagoryName
                //});
            };
        }

        public void Start()
        {
            this.subscriber.Subscribe();
        }

        public void Stop()
        {
            this.subscriber.Unsubscribe();
        }
    }
}
