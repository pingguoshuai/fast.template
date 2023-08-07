using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.IdentityServer.ApiScopes;

namespace Fast.Template.IdsAdmin.EntityFrameworkCore;

[DependsOn(
    typeof(IdsAdminDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
[DependsOn(typeof(AbpIdentityServerEntityFrameworkCoreModule))]
    public class IdsAdminEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<IdsAdminDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                //options.AddDefaultRepository<ApiScopeProperty>();
        });
    }
}
