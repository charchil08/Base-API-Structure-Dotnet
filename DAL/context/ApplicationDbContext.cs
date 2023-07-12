using Common.Helper;
using EAL.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DAL.context;

public class ApplicationDbContext : DbContext
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => IsTimestampedEntity(e.Entity.GetType()) &&
                (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            if (IsTimestampedEntity(entityEntry.Entity.GetType()))
            {
                var timeStampedEntity = (dynamic)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    timeStampedEntity.CreatedOn = DateTimeHelper.GetDateTimeOffsetNow();
                }
                timeStampedEntity.ModifiedOn = DateTimeHelper.GetDateTimeOffsetNow();
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    private static bool IsTimestampedEntity(Type entityType)
    {
        var baseType = entityType.BaseType;
        while (baseType != null)
        {
            if (baseType.IsGenericType &&
                baseType.GetGenericTypeDefinition() == typeof(TimestampedEntity<>))
            {
                return true;
            }
            baseType = baseType.BaseType;
        }
        return false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}