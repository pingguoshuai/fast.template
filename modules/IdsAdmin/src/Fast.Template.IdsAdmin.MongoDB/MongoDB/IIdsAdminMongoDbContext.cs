using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Fast.Template.IdsAdmin.MongoDB;

[ConnectionStringName(IdsAdminDbProperties.ConnectionStringName)]
public interface IIdsAdminMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
