using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Fast.Template.Basic;
using Fast.Template.IdsAdmin;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Fast.Template.Start.EntityFrameworkCore;
using Fast.Template.Start.MultiTenancy;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Logging;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Modularity;
using Volo.Abp.Reflection;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;
using Microsoft.AspNetCore.Mvc;

namespace Fast.Template.Start;

[DependsOn(
    typeof(StartHttpApiModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(StartApplicationModule),
    typeof(StartEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class StartHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        ConfigureConventionalControllers();
        ConfigureAuthentication(context, configuration);
        ConfigureCache(configuration);
        ConfigureVirtualFileSystem(context);
        ConfigureDataProtection(context, configuration, hostingEnvironment);
        ConfigureDistributedLocking(context, configuration);
        ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);
    }

    private void ConfigureCache(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "Start:"; });
    }

    private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<StartDomainSharedModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Fast.Template.Start.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<StartDomainModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Fast.Template.Start.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<StartApplicationContractsModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Fast.Template.Start.Application.Contracts"));
                options.FileSets.ReplaceEmbeddedByPhysical<StartApplicationModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Fast.Template.Start.Application"));
            });
        }
    }

    private void ConfigureConventionalControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(StartApplicationModule).Assembly);
            options.ConventionalControllers.Create(typeof(IdsAdminApplicationModule).Assembly, ops =>
            {
                ops.RootPath = "IdsAdmin";
            });
            options.ConventionalControllers.Create(typeof(BasicApplicationModule).Assembly, ops =>
            {
                ops.RootPath = "Basic";
            });
        });
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.Audience = "Template";
            });
    }

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"],
            new Dictionary<string, string>
            {
                    {"Template", "Template API"}
            },
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Start API", Version = "v1" });

                var moduleContainer = context.Services.GetRequiredService<IModuleContainer>();
                var groups = moduleContainer.Modules.Where(m => m.Type.GetCustomAttribute<DescriptionAttribute>() != null).ToList();
                var names = groups.Select(g => g.Assembly.GetName().Name).ToList();
                if (groups.Any())
                {
                    foreach (var item in groups)
                    {
                        //item.Assembly.GetName().Name;
                        options.SwaggerDoc(item.Assembly.GetName().Name, new OpenApiInfo { Title = item.Type.GetCustomAttribute<DescriptionAttribute>()?.Description, Version = "v1" });
                    }
                }

                //options.DocInclusionPredicate((docName, description) => true);
                options.DocInclusionPredicate((docName, description) =>
                {
                    var groupName = docName;
                    var assemblyName = ((ControllerActionDescriptor)description.ActionDescriptor).ControllerTypeInfo.Assembly.GetName().Name;
                    if (groupName == "v1" && !names.Contains(assemblyName))
                    {
                        return true;
                    }

                    if (groupName == assemblyName) return true;
                    return false;
                });
                options.CustomSchemaIds(type => type.FullName);
                options.ResolveConflictingActions(api => api.First());

                #region 注释：反射扫描xml文件

                var assemblyFinder = context.Services.GetRequiredService<IAssemblyFinder>();

                var assemblies = assemblyFinder.Assemblies.ToList();
                foreach (var assembly in assemblies)
                {
                    string xmlFileName = assembly.GetName().Name + ".xml"; // 获取 XML 文件名
                    string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlFileName);
                    if (File.Exists(xmlFilePath))
                    {
                        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName), true);
                    }
                }

                #endregion
            });
    }

    private void ConfigureDataProtection(
        ServiceConfigurationContext context,
        IConfiguration configuration,
        IWebHostEnvironment hostingEnvironment)
    {
        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("Start");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "Start-Protection-Keys");
        }
    }

    private void ConfigureDistributedLocking(
        ServiceConfigurationContext context,
        IConfiguration configuration)
    {
        context.Services.AddSingleton<IDistributedLockProvider>(sp =>
        {
            var connection = ConnectionMultiplexer
                .Connect(configuration["Redis:Configuration"]);
            return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
        });
    }

    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(configuration["App:CorsOrigins"]?
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(o => o.RemovePostFix("/"))
                        .ToArray() ?? Array.Empty<string>())
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            var moduleContainer = app.ApplicationServices.GetRequiredService<IModuleContainer>();
            var groups = moduleContainer.Modules.Where(m => m.Type.GetCustomAttribute<DescriptionAttribute>() != null).ToList();
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Template API");
            if (groups.Any())
            {
                foreach (var item in groups)
                {
                    options.SwaggerEndpoint($"/swagger/{item.Assembly.GetName().Name}/swagger.json", item.Type.GetCustomAttribute<DescriptionAttribute>()?.Description);
                }
            }

            var configuration = context.GetConfiguration();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            options.OAuthScopes("Template");
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }
}
