using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Exercise.EntityFramework.Patterns.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All(params Expression<Func<T, object>>[] includings);
        void Delete(int id);
        T FindByKey(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includings);
        T Insert(T entity);
        void Update(T entity);
    }
}