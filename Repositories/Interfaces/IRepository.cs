using System.Linq.Expressions;

namespace BankingApp.Repositories.Interfaces

{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>>[]? filter = null, Expression<Func<T, object>>[]? includes = null);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}


