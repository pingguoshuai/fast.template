using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using System;
using Volo.Abp.Timing;
using System.ComponentModel;
using Fast.Template.Common.Applicaiton;
using Fast.Template.Common.Utils.Attributes;
using Fast.Template.Common.Permission;

namespace Fast.Template.IdsAdmin;

[DependsOn(
    typeof(IdsAdminDomainModule),
    typeof(IdsAdminApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(CommonApplicationModule),
    typeof(CommonPermissionModule)
    )]
[Description("授权中心")]
[Group("IdsAdmin")]
public class IdsAdminApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<IdsAdminApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<IdsAdminApplicationModule>(validate: true);
        });

        Configure<AbpClockOptions>(options =>
        {
            options.Kind = DateTimeKind.Local;
        });

        //Configure<AbpJsonOptions>(options =>
        //{
        //    options.DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        //});  

        //var mvcCoreBuilder = context.Services.AddMvcCore(options =>
        //{
        //    options.Filters.Add(new ApiExplorerSettingsAttribute());
        //    options.Filters.Add()
        //});
    }
}
