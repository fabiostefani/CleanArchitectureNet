using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace fabiostefani.io.CleanArch.Repository.database
{
    public interface IDatabase
    {
        IQueryable<TEntity> Many<TEntity>(Func<TEntity, bool> where, params Expression<Func<TEntity,object>>[] includes) where TEntity : class;
        T One<T>(Func<T, bool> where, params Expression<Func<T,object>>[] includes) where T : class;
        void Add<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
        void Remove<T>(T item) where T : class;
        void RemoveRange<T>(params T[] items) where T : class;
    }
}