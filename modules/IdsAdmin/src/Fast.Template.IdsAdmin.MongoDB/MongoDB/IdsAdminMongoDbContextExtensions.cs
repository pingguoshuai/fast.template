using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Fast.Template.IdsAdmin.MongoDB;

public static class IdsAdminMongoDbContextExtensions
{
    public static void ConfigureIdsAdmin(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
