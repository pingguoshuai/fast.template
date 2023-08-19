using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Fast.Template.Basic.Localization;
using Fast.Template.Common.Permission.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Fast.Template.Common.Permission;

namespace Fast.Template.Basic;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(CommonPermissionModule)
)]
public class BasicDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BasicDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<BasicResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Basic");

            options.Resources
                .Get<CommonPermissionResource>()
                .AddVirtualJson("/Localization/Permission");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Basic", typeof(BasicResource));
        });
    }
}
