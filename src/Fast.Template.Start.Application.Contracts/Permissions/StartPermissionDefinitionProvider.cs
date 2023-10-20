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
        //var myGroup = context.AddGroup(StartPermissions.GroupName);

        var myGroup = context.AddGroup(StartPermissions.GroupName, L("Permission:Start"));

        var dicTypePermission = myGroup.AddPermission("Start.User.Default", L("Permission:User"));
        dicTypePermission.AddChild("Start.User.Create", L("Permission:Create"));
        dicTypePermission.AddChild("Start.User.Update", L("Permission:Update"));
        dicTypePermission.AddChild("Start.User.Delete", L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StartResource>(name);
    }
}
