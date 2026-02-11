using Gestao.Cadastro.Digital.Domain.Interfaces.Base;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;

public class RepositoryBase<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    protected RepositoryBase(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(long id)
        => await _dbSet.FindAsync(id);

    public virtual async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.AsNoTracking().ToListAsync();

    public virtual async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

    public virtual void Update(T entity)
        => _dbSet.Update(entity);

    public virtual void Remove(T entity)
        => _dbSet.Remove(entity);

    public virtual async Task<bool> ExistsAsync(long id)
        => await _dbSet.FindAsync(id) != null;
}
