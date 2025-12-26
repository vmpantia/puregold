using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Puregold.Application.Abstractions.Repositories;
using Puregold.Domain.Common.Interfaces;
using Puregold.Infra.Database.Contexts;

namespace Puregold.Infra.Database.Repositories;

public class BaseRepository<TEntity>(PuregoldDbContext context) : IBaseRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _table = context.Set<TEntity>();

    public IQueryable<TEntity> Get() => _table;
    
    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression) => _table.Where(expression);

    public async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default) => await _table.FirstOrDefaultAsync(expression, cancellationToken);
    
    public bool IsExist(Expression<Func<TEntity, bool>> expression) => _table.Any(expression);
    
    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default) => await _table.AnyAsync(expression, cancellationToken);

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await _table.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return result.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = _table.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        
        return result.Entity;
    }
}