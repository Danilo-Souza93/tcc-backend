using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using tcc.Context;

namespace tcc.Repositorys
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected APIDbContext DbContext { get; set; }
        public RepositoryBase(APIDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Create(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.DbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.DbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> GetAll()
        {
            return this.DbContext.Set<T>().AsNoTracking();
        }
    }
}
