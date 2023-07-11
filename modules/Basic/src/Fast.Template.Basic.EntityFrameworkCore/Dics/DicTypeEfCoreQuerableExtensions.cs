using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Fast.Template.Basic.Dics;

/// <summary>
/// 字典类型
/// </summary>
public static class DicTypeEfCoreQueryableExtensions
{
    public static IQueryable<DicType> IncludeDetails(this IQueryable<DicType> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
