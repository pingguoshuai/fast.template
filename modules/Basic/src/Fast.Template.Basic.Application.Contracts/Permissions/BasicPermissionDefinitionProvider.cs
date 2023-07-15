using Fast.Template.Basic.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Fast.Template.Basic.Permissions;

public class BasicPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BasicPermissions.GroupName, L("Permission:Basic"));

        var dicTypePermission = myGroup.AddPermission(BasicPermissions.DicType.Default, L("Permission:DicType"));
        dicTypePermission.AddChild(BasicPermissions.DicType.Create, L("Permission:Create"));
        dicTypePermission.AddChild(BasicPermissions.DicType.Update, L("Permission:Update"));
        dicTypePermission.AddChild(BasicPermissions.DicType.Delete, L("Permission:Delete"));

        var dicinfoPermission = myGroup.AddPermission(BasicPermissions.Dicinfo.Default, L("Permission:Dicinfo"));
        dicinfoPermission.AddChild(BasicPermissions.Dicinfo.Create, L("Permission:Create"));
        dicinfoPermission.AddChild(BasicPermissions.Dicinfo.Update, L("Permission:Update"));
        dicinfoPermission.AddChild(BasicPermissions.Dicinfo.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BasicResource>(name);
    }
}
