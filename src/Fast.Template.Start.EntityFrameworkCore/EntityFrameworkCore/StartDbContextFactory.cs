using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using static Fast.Template.Start.EntityFrameworkCore.StartDbContext;

namespace Fast.Template.Start.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class StartDbContextFactory : IDesignTimeDbContextFactory<StartDbContext>
{
    public StartDbContext CreateDbContext(string[] args)
    {
        StartEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<StartDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default")).ReplaceService<ISqlGenerationHelper, RivenPostgreSqlGenerationHelper>();

        return new StartDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Fast.Template.Start.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
