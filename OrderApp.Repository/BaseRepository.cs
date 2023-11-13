using Microsoft.EntityFrameworkCore;
using OrderApp.Contract;
using System.Linq.Expressions;

namespace OrderApp.Repository
{
    public abstract class BaseRepository<T> : IRepositoryBase<T> where T : class
    {
        protected OrderAppDbContext context { get; set; }

        public BaseRepository(OrderAppDbContext orderAppDbContext)
        {
            context = orderAppDbContext;
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? context.Set<T>() : context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByConditions(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? context.Set<T>().Where(expression): context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
