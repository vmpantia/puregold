using System.Linq.Expressions;
using Puregold.Domain.Common;

namespace Puregold.Application.Abstractions.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> Get();
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    bool IsExist(Expression<Func<TEntity, bool>> expression);
    Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
}