using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace fabiostefani.io.CleanArch.Repository.database.ef
{
    public class EfDataBase : IDatabase
    {
        
        public EfDataBase()
        {
            
        }

        public IQueryable<TEntity> Many<TEntity>(Func<TEntity, bool> where) where TEntity : class
        {
            IQueryable<TEntity> list;
            using (var context = new CleanArchContext())
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
 
                //Apply eager loading
                //foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                //    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                 
                list = dbQuery.AsNoTracking().Where(where).AsQueryable<TEntity>();
            }
            return list;
        }

        public T One<T>(Func<T, bool> where) where T : class
        {
            T? item = null;
            using (var context = new CleanArchContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                 
                //Apply eager loading
                // foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                //     dbQuery = dbQuery.Include<T, object>(navigationProperty);
 
                item = dbQuery.AsNoTracking().FirstOrDefault(where); //Apply where clause
            }
            return item;
        }
    }
}