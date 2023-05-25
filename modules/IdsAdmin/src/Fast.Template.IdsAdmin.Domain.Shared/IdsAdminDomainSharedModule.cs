using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Fast.Template.IdsAdmin.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.IdentityServer;

namespace Fast.Template.IdsAdmin;

[DependsOn(
    typeof(AbpValidationModule)
)]
[DependsOn(typeof(AbpIdentityServerDomainSharedModule))]
    public class IdsAdminDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IdsAdminDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<IdsAdminResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/IdsAdmin");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("IdsAdmin", typeof(IdsAdminResource));
        });
    }
}
