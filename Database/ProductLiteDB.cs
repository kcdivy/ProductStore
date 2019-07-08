using LiteDB;
using ProductQueryModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database
{
    public class ProductLiteDB : GenericLiteDB<Product>, IProductDatabase
    {
        public ProductLiteDB()
        {

        }
        public override void Delete(Product product, string connectionString)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var products = db.GetCollection<Product>();
                products.Delete(product.ProductId);
            }
        }

        public override Product GetById(object id, string connectionString)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var products = db.GetCollection<Product>();
                var retrievedProduct = products.FindOne(p => p.ProductId.Equals(id));
                return retrievedProduct;
            }
        }
        public IEnumerable<Product> GetMatchingProducts(string searchedCriteria, string connectionString)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var products = db.GetCollection<Product>();
                var retrievedProducts = products.Find(prod => prod.ProductName.Contains(searchedCriteria)
                                                             || prod.Description.Contains(searchedCriteria));
                                                             //|| prod.Catagory.CatagoryName.Contains(searchedCriteria)
                                                             //|| prod.Catagory.CatagoryDesc.Contains(searchedCriteria)
                                                             //|| prod.Catagory.CatagoryCode.Contains(searchedCriteria)).ToList();
                return retrievedProducts;
            }
        }
    }
}
