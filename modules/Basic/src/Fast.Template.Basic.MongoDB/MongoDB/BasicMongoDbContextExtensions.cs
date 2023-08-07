using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Fast.Template.Basic.MongoDB;

public static class BasicMongoDbContextExtensions
{
    public static void ConfigureBasic(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
