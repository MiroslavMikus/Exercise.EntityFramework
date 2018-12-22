using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.Patterns.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> All(params Expression<Func<T, object>>[] includings)
        {
            return GetAllIncluding(includings).AsEnumerable();
        }

        public T FindByKey(int id) => _dbSet.Find(id);

        public T Insert(T entity) => _dbSet.Add(entity);
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id) => _dbSet.Remove(_dbSet.Find(id));

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includings)
        {
            return GetAllIncluding(includings).Where(predicate).AsEnumerable();
        }

        private IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includings)
        {
            return includings.Aggregate(_dbSet as IQueryable<T>, (current, included) => current.Include(included));
        }
    }
}
