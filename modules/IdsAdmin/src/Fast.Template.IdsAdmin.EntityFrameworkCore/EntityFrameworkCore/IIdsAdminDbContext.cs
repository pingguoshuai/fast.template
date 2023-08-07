using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Fast.Template.IdsAdmin.EntityFrameworkCore;

[ConnectionStringName(IdsAdminDbProperties.ConnectionStringName)]
public interface IIdsAdminDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
