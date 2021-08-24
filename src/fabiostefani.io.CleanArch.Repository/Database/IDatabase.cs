using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace fabiostefani.io.CleanArch.Repository.database
{
    public interface IDatabase
    {
        IQueryable<TEntity> Many<TEntity>(Func<TEntity, bool> where, params Expression<Func<TEntity,object>>[] includes) where TEntity : class;
        Task<IList<TEntity>> All<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
        Task<T> One<T>(Expression<Func<T, bool>> where, params Expression<Func<T,object>>[] includes) where T : class;
        Task Add<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
        Task Remove<T>(T item) where T : class;        
        Task RemoveRange<T>(IList<T> items) where T : class;
    }
}