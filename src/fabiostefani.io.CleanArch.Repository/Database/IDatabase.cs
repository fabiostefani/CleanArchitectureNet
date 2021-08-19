using System;
using System.Linq;
namespace fabiostefani.io.CleanArch.Repository.database
{
    public interface IDatabase
    {
        IQueryable<TEntity> Many<TEntity>(Func<TEntity, bool> where) where TEntity : class;
        T One<T>(Func<T, bool> where) where T : class;
    }
}