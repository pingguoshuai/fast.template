using Fast.Template.Basic.Dics;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Fast.Template.Basic.EntityFrameworkCore;

[DependsOn(
    typeof(BasicDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class BasicEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<BasicDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            options.AddRepository<DicType, DicTypeRepository>();
        });
    }
}
