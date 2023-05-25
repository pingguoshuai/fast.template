using Localization.Resources.AbpUi;
using Fast.Template.IdsAdmin.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Fast.Template.IdsAdmin;

[DependsOn(
    typeof(IdsAdminApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class IdsAdminHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(IdsAdminHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<IdsAdminResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
