using Volo.Abp.Modularity;

namespace Fast.Template.Start;

[DependsOn(
    typeof(StartApplicationModule),
    typeof(StartDomainTestModule)
    )]
public class StartApplicationTestModule : AbpModule
{

}
