using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Fast.Template.IdsAdmin;

[DependsOn(
    typeof(IdsAdminApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class IdsAdminHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(IdsAdminApplicationContractsModule).Assembly,
            IdsAdminRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IdsAdminHttpApiClientModule>();
        });

    }
}
