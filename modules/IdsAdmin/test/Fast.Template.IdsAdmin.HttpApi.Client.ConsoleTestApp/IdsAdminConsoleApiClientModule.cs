using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Fast.Template.IdsAdmin;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IdsAdminHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class IdsAdminConsoleApiClientModule : AbpModule
{

}
