using Fast.Template.Common.Permission.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Fast.Template.Common.Permission
{
    [DependsOn(
        //typeof(AbpDddApplicationModule),
        //typeof(AbpHttpModule),
        //typeof(AbpAuthorizationModule),
        typeof(AbpLocalizationModule)
            )]
    public class CommonPermissionModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CommonPermissionModule>("Fast.Template.Common.Permission");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<CommonPermissionResource>("en")
                    //.AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Permission");
            });
            Configure<AbpLocalizationOptions>(options =>
            {
                options.DefaultResourceType = typeof(CommonPermissionResource);
            });

        }
    }
}
