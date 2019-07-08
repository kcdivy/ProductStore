using LiteDB;
using ProductQueryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class CatagoryLiteDB : GenericLiteDB<Catagory>, ICatagoryDatabase
    {
        public override void Delete(Catagory entity, string connectionString)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var catagories = db.GetCollection<Catagory>();
                catagories.Delete(entity.CatagoryId);
            }
        }

        public override Catagory GetById(object id, string connectionString)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var categories = db.GetCollection<Catagory>();
                var retrievedCategory = categories.FindOne(p => p.CatagoryId.Equals(id));
                return retrievedCategory;
            }
        }

        public Catagory GetByName(object name, string connectionString)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var categories = db.GetCollection<Catagory>();
                var retrievedCategory = categories.FindOne(p => p.CatagoryName.Equals(name.ToString()));
                return retrievedCategory;
            }
        }

    }
}
