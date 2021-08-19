using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace fabiostefani.io.CleanArch.Repository.database.ef
{
    public class EfDataBase : IDatabase
    {
        
        public EfDataBase()
        {
            
        }

        public IQueryable<TEntity> Many<TEntity>(Func<TEntity, bool> where, params Expression<Func<TEntity,object>>[] includes) where TEntity : class
        {
            IQueryable<TEntity> list;
            using (var context = new CleanArchContext())
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();
 
                //Apply eager loading
                foreach (Expression<Func<TEntity, object>> navigationProperty in includes)
                    dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

                list = dbQuery.AsNoTracking().Where(where).AsQueryable<TEntity>();
            }
            return list;
        }

        public T One<T>(Func<T, bool> where, params Expression<Func<T,object>>[] includes) where T : class
        {
            T? item = null;
            using (var context = new CleanArchContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                 
                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in includes)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
 
                item = dbQuery.AsNoTracking().FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        public async void Add<T>(T item) where T : class
        {
            using (var context = new CleanArchContext())
            {
                context.Entry(item).State = EntityState.Added;                
                await context.SaveChangesAsync();
            }

        }
        public async void Update<T>(T item) where T : class
        {
            using (var context = new CleanArchContext())
            {
                context.Entry(item).State = EntityState.Modified;                
                await context.SaveChangesAsync();
            }
        }
        public async void Remove<T>(T item) where T : class
        {
            using (var context = new CleanArchContext())
            {
                context.Entry(item).State = EntityState.Deleted;                
                await context.SaveChangesAsync();
            } 
        }

        public async void RemoveRange<T>(params T[] items) where T : class
        {
            using (var context = new CleanArchContext())
            {       
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
                await context.SaveChangesAsync();
            }
        }
    }
}