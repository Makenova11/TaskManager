using System.Linq.Expressions;

namespace TaskManager.Interfaces
{
    /// <summary>
    /// Базовый репозиторий.
    /// </summary>
    public interface IEntityBaseRepository<T> where T : class, new()
    {
        public Task<IEnumerable<T>> AllIncludingAsync(
          params Expression<Func<T, object>>[] includeProperties
        );
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<int> CountAsync();
        public Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate);
        public Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate,
          params Expression<Func<T, object>>[] includeProperties);
        public Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        public Task AddTaskAsync(T entity);
        public Task UpdateTaskAsync(T entity);
        public Task DeleteTaskAsync(T entity);
        public Task DeleteWhereAsync(Expression<Func<T, bool>> predicate);
        public Task SaveAsync();
    }
}
