using System.Linq.Expressions;

namespace tcc.Repositorys
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
