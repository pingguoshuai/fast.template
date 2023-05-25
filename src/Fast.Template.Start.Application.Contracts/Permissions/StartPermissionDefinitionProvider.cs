using Fast.Template.Start.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Fast.Template.Start.Permissions;

public class StartPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StartPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(StartPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StartResource>(name);
    }
}
