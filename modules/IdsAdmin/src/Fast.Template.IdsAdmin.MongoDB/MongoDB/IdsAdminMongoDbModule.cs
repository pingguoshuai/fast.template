using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.IdentityServer.MongoDB;

namespace Fast.Template.IdsAdmin.MongoDB;

[DependsOn(
    typeof(IdsAdminDomainModule),
    typeof(AbpMongoDbModule)
    )]
[DependsOn(typeof(AbpIdentityServerMongoDbModule))]
    public class IdsAdminMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<IdsAdminMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
