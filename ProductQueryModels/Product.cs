using System;

namespace ProductQueryModels
{
    public class Product
    {
        //[BsonId]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CatagoryId { get; set; }
    }
}
