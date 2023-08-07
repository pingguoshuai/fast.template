using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;

namespace Fast.Template.IdsAdmin.EntityFrameworkCore;

[ConnectionStringName(IdsAdminDbProperties.ConnectionStringName)]
public class IdsAdminDbContext : AbpDbContext<IdsAdminDbContext>, IIdsAdminDbContext
{
    private readonly ILogger<IdsAdminDbContext> _logger;
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public IdsAdminDbContext(DbContextOptions<IdsAdminDbContext> options, ILogger<IdsAdminDbContext> logger)
        : base(options)
    {
        _logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureIdsAdmin();
        builder.ConfigureIdentityServer();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(log => _logger?.LogDebug(log), new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
    }
}
