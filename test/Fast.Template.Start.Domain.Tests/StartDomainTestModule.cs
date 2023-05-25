using Fast.Template.Start.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Fast.Template.Start;

[DependsOn(
    typeof(StartEntityFrameworkCoreTestModule)
    )]
public class StartDomainTestModule : AbpModule
{

}
