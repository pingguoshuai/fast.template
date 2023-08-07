using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Fast.Template.IdsAdmin;

[DependsOn(
    typeof(IdsAdminDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class IdsAdminApplicationContractsModule : AbpModule
{

}
