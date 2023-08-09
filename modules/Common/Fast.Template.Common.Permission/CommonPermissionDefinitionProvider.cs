using Fast.Template.Common.Permission.Localization;
using Fast.Template.Common.Utils.Attributes;
using System;
using System.Linq;
using System.Reflection;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Http;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Fast.Template.Common.Permission
{
    public class CommonPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        private readonly IModuleContainer _moduleContainer;

        public CommonPermissionDefinitionProvider(IModuleContainer moduleContainer)
        {
            _moduleContainer = moduleContainer;
        }

        public override void Define(IPermissionDefinitionContext context)
        {
            var modules = _moduleContainer.Modules.Where(m => m.Type.GetCustomAttribute<GroupAttribute>() != null).ToList();

            foreach (var module in modules)
            {
                var groupName = module.Type.GetCustomAttribute<GroupAttribute>().Name;

                var myGroup = context.AddGroup(groupName, L($"Permission:{groupName}"));

                var services = module.Assembly.GetTypes().Where(t => typeof(IRemoteService).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract).ToList();

                foreach(var service in services)
                {
                    var serviceName = service.Name.RemovePostFix(ApplicationService.CommonPostfixes);

                    var permission = myGroup.AddPermission($"{groupName}.{serviceName}", L($"Permission:{serviceName}"));

                    var actions = service.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                        .Where(method => !method.IsSpecialName
                                                        && method.Name != nameof(GetType)
                                                        && method.Name != nameof(ToString)
                                                        && method.Name != nameof(Equals)
                                                        && method.Name != nameof(GetHashCode)).ToList();
                    foreach (var action in actions)
                    {
                        var methodName = action.Name;
                        //var httpMethod = HttpMethodHelper.GetConventionalVerbForMethodName(methodName);
                        //var name = HttpMethodHelper.RemoveHttpMethodPrefix(methodName, httpMethod);

                        permission.AddChild($"{groupName}.{serviceName}.{methodName}", L($"Permission:{methodName}"));
                    }
                }
            }
        }
    
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CommonPermissionResource>(name);
        }
    }
}
