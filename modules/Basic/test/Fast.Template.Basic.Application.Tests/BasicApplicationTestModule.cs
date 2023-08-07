using Volo.Abp.Modularity;

namespace Fast.Template.Basic;

[DependsOn(
    typeof(BasicApplicationModule),
    typeof(BasicDomainTestModule)
    )]
public class BasicApplicationTestModule : AbpModule
{

}
