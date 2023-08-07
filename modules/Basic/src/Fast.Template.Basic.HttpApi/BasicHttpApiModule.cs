using Localization.Resources.AbpUi;
using Fast.Template.Basic.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Fast.Template.Basic;

[DependsOn(
    typeof(BasicApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class BasicHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BasicHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BasicResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
