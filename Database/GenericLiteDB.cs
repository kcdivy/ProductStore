using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public abstract class GenericLiteDB<TEntity> : IDatabase<TEntity> where TEntity : class
    {
        public abstract void Delete(TEntity entity, string connectionString);
        //{
        //    using (var db = new LiteDatabase(connectionString))
        //    {
        //        var products = db.GetCollection<TEntity>();
        //        products.Delete(q=>q.id);
        //    }
        //}

        public IEnumerable<TEntity> GetAll(string connectionString)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var products = db.GetCollection<TEntity>();
                return products.FindAll();
            }
        }

        public abstract TEntity GetById(object id, string connectionString);
       

        public void Insert(TEntity entity, string connectionString)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var products = db.GetCollection<TEntity>();
                products.Insert(entity);
            }
        }
    }
}
