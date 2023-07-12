using System.Linq.Expressions;
using EAL.DTOs;

namespace BAL.Service.Infrastructure;
public interface IBaseService<T> where T : class
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);

    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task<T?> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[]? includes = null, string[]? thenIncludes = null, Expression<Func<T, T>>? selects = null, CancellationToken cancellationToken = default);
    Task<PageListResponseDTO<T>> GetAllAsync(PageListRequestEntity<T> pageListRequest);
}

