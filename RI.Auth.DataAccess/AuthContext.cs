using Microsoft.EntityFrameworkCore;
using RI.Commons.Abstraction;

namespace RI.Auth.DataAccess;

internal sealed class AuthContext : DbContext
{
    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        BeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void BeforeSave()
    {
        if (!ChangeTracker.HasChanges())
        {
            return;
        }

        var timeNow = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries())
        {
            var entity = entry.Entity;
            switch (entry.State)
            {
                case EntityState.Added:
                    if (entity is ICreated createdEntity)
                    {
                        createdEntity.Created = timeNow;
                    }

                    break;

                case EntityState.Modified:
                    if (entity is IUpdated updatedEntity)
                    {
                        updatedEntity.Updated = timeNow;
                    }

                    break;
            }
        }
    }
}