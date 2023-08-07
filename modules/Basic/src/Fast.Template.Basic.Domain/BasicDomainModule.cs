using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Fast.Template.Basic;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(BasicDomainSharedModule)
)]
public class BasicDomainModule : AbpModule
{

}
