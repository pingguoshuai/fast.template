using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Fast.Template.Basic;

[DependsOn(
    typeof(BasicApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class BasicHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(BasicApplicationContractsModule).Assembly,
            BasicRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BasicHttpApiClientModule>();
        });

    }
}
