using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Fast.Template.Start.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Fast.Template.Start.Permissions;

public class StartPermissionDefinitionProvider : PermissionDefinitionProvider
{
    private readonly IModuleContainer _moduleContainer;

    public StartPermissionDefinitionProvider(IModuleContainer moduleContainer)
    {
        _moduleContainer = moduleContainer;
    }

    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StartPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(StartPermissions.MyPermission1, L("Permission:MyPermission1"));

        //反射
        var permissionModules = _moduleContainer.Modules.Where(m => m.Type.GetCustomAttribute<DescriptionAttribute>() != null).ToList();

        foreach (var module in permissionModules)
        {
            //查找service
            var services = module.Assembly.GetTypes().Where(t => typeof(IApplicationService).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract).ToList();

            foreach (var service in services)
            {
                //myGroup.AddPermission(service.Name.Replace("AppService",""));

                //获取方法
                var methods = service.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            }
        }
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StartResource>(name);
    }
}
