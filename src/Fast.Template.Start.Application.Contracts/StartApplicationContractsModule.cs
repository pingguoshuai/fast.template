using Fast.Template.Basic;
using Fast.Template.Common.Permission;
using Fast.Template.IdsAdmin;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Fast.Template.Start;

[DependsOn(
    typeof(StartDomainSharedModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(IdsAdminApplicationContractsModule),
    typeof(BasicApplicationContractsModule),
    typeof(AbpObjectExtendingModule)
)]
public class StartApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        StartDtoExtensions.Configure();
    }
}
