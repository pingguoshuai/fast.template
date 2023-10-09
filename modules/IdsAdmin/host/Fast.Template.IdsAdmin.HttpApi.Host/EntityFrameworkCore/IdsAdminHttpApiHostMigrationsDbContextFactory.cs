using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Fast.Template.IdsAdmin.EntityFrameworkCore;

public class IdsAdminHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<IdsAdminHttpApiHostMigrationsDbContext>
{
    public IdsAdminHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<IdsAdminHttpApiHostMigrationsDbContext>()
            .UseNpgsql(configuration.GetConnectionString("IdsAdmin"), MySqlServerVersion.LatestSupportedServerVersion);

        return new IdsAdminHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
