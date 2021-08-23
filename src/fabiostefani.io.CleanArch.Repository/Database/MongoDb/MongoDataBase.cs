using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using fabiostefani.io.CleanArch.Repository.database;

namespace fabiostefani.io.CleanArch.Repository.Database.MongoDb
{
    public class MongoDataBase : IDatabase
    {
        public void Add<T>(T item) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Many<TEntity>(Func<TEntity, bool> where, params Expression<Func<TEntity,object>>[] includes) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Many<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<T> One<T>(Expression<Func<T, bool>> where, params Expression<Func<T,object>>[] includes) where T : class
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T item) where T : class
        {
            throw new NotImplementedException();
        }

        public void RemoveRange<T>(params T[] items) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T item) where T : class
        {
            throw new NotImplementedException();
        }
    }
}