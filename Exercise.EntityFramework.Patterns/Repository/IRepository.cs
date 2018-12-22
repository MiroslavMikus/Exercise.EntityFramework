using System.Linq;

namespace Exercise.EntityFramework.Patterns.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        void Delete(int id);
        T Find(int id);
        T Insert(T entity);
        void Update(T entity);
    }
}