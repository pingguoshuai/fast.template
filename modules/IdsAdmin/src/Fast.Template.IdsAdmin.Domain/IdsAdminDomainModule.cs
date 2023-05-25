using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.IdentityServer;
using Volo.Abp.PermissionManagement.IdentityServer;

namespace Fast.Template.IdsAdmin;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(IdsAdminDomainSharedModule)
)]
[DependsOn(typeof(AbpIdentityServerDomainModule))]
    [DependsOn(typeof(AbpPermissionManagementDomainIdentityServerModule))]
    public class IdsAdminDomainModule : AbpModule
{

}
