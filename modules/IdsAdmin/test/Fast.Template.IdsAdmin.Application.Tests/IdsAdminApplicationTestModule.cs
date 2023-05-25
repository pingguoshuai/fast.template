using Volo.Abp.Modularity;

namespace Fast.Template.IdsAdmin;

[DependsOn(
    typeof(IdsAdminApplicationModule),
    typeof(IdsAdminDomainTestModule)
    )]
public class IdsAdminApplicationTestModule : AbpModule
{

}
