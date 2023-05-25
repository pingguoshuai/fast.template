using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Fast.Template.IdsAdmin.EntityFrameworkCore;

public class IdsAdminHttpApiHostMigrationsDbContext : AbpDbContext<IdsAdminHttpApiHostMigrationsDbContext>
{
    public IdsAdminHttpApiHostMigrationsDbContext(DbContextOptions<IdsAdminHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureIdsAdmin();
    }
}
