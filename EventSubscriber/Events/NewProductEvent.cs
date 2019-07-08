using ProductQueryModels;
using System;

namespace EventSubscriber.Events
{
    public class NewProductEvent
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatagoryId { get; set; }
        public string CatagoryCode { get; set; }
        public string CatagoryName { get; set; }
        public string CatagoryDesc { get; set; }
    }
}
