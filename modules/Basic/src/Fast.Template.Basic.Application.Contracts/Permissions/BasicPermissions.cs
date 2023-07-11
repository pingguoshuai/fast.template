using Volo.Abp.Reflection;

namespace Fast.Template.Basic.Permissions;

public class BasicPermissions
{
    public const string GroupName = "Basic";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(BasicPermissions));
    }
    /// <summary>
    /// 字典类型
    /// </summary>
    public class DicType
    {
        public const string Default = GroupName + ".DicType";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
