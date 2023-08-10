﻿using Fast.Template.Common.Permission.Localization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Authorization.Localization;
using Volo.Abp.Http;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Fast.Template.Common.Permission
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(AbpHttpModule),
        typeof(AbpAuthorizationModule)
            )]
    public class CommonPermissionModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CommonPermissionResource>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<CommonPermissionResource>("en")
                    .AddVirtualJson("/Localization/Permission");
            });
        }
    }
}