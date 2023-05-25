using Volo.Abp.Reflection;

namespace Fast.Template.IdsAdmin.Permissions;

public class IdsAdminPermissions
{
    public const string GroupName = "IdsAdmin";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(IdsAdminPermissions));
    }
}
