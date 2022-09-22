namespace IdentityTask.Core.Interfaces;

public interface IGenericRepository<T>
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<int> CountAsync(CancellationToken cancellationToken);
    Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken);
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken);
    Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    Task<T> FirstAsync(ISpecification<T> specification, CancellationToken cancellationToken);
    Task<T> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> ListAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
}
