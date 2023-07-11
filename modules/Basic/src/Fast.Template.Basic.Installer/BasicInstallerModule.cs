using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Fast.Template.Basic;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class BasicInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BasicInstallerModule>();
        });
    }
}
