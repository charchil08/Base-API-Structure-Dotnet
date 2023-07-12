using DAL.context;
using DAL.Infrastructure;

namespace DAL.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public IBaseRepo<T> GetRepository<T>() where T : class
    {
        return new BaseRepo<T>(_context);
    }
    public void Save()
        => _context.SaveChanges();

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();

    public void Rollback()
        => _context.Dispose();

    public async Task RollbackAsync()
        => await _context.DisposeAsync();
}