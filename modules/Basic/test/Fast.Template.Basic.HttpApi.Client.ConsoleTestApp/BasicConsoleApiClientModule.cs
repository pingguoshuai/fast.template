using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Fast.Template.Basic;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BasicHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class BasicConsoleApiClientModule : AbpModule
{

}
