using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Fast.Template.Common.Permission;

namespace Fast.Template.Basic;

[DependsOn(
    typeof(BasicDomainModule),
    typeof(BasicApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(CommonPermissionModule)
    )]
[Description("基础建设")]
public class BasicApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<BasicApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BasicApplicationModule>(validate: true);
        });
    }
}
