namespace DAL.Infrastructure;

public interface IUnitOfWork
{
    void Save();
    void Rollback();
    IBaseRepo<T> GetRepository<T>() where T : class;
    Task SaveAsync();
    Task RollbackAsync();
}
