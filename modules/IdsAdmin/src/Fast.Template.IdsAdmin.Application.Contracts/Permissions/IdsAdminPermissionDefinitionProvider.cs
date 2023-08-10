using Fast.Template.IdsAdmin.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Fast.Template.IdsAdmin.Permissions;

public class IdsAdminPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //var myGroup = context.AddGroup(IdsAdminPermissions.GroupName, L("Permission:IdsAdmin"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IdsAdminResource>(name);
    }
}
