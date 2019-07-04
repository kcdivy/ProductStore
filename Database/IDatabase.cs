using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public interface IDatabase<TEntity> where TEntity:class
    {
        void Insert(TEntity entity, string connectionString);

        TEntity GetById(object id, string connectionString);

        void Delete(TEntity entity, string connectionString);

        IEnumerable<TEntity> GetAll(string connectionString);


    }
}
