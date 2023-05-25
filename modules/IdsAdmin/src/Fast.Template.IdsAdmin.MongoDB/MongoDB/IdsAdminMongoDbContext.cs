using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Fast.Template.IdsAdmin.MongoDB;

[ConnectionStringName(IdsAdminDbProperties.ConnectionStringName)]
public class IdsAdminMongoDbContext : AbpMongoDbContext, IIdsAdminMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureIdsAdmin();
    }
}
