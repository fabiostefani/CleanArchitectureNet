using System;
using System.Linq;
using fabiostefani.io.CleanArch.Repository.database;

namespace fabiostefani.io.CleanArch.Repository.Database.MongoDb
{
    public class MongoDataBase : IDatabase
    {
        public IQueryable<TEntity> Many<TEntity>(Func<TEntity, bool> where) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public T One<T>(Func<T, bool> where) where T : class
        {
            throw new NotImplementedException();
        }
    }
}