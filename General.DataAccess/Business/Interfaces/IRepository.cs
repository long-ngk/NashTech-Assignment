using System.Linq.Expressions;

namespace General.DataAccess.Business.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithSortedAsync(string sortOrder, Expression<Func<T, object>> filter);
        Task<T> GetByIdAsync(object id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(object id);
    }

}
